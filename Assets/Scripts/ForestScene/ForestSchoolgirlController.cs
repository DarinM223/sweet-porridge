using UnityEngine;
using System.Collections;

public class ForestSchoolgirlController : MonoBehaviour {
	private Animator animator;
	public delegate void SchoolgirlAction();
	public static event SchoolgirlAction OnFinishedWalking;

	private IEnumerator initialWalk() {
		animator.SetInteger("Walking", 1);
		yield return new WaitForSeconds(2);
		animator.SetInteger("Walking", 0);
		yield return new WaitForSeconds(1);
		if (OnFinishedWalking != null) {
			OnFinishedWalking();
		}
	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		StartCoroutine(initialWalk());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
