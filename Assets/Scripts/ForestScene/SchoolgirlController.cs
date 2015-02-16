using UnityEngine;
using System.Collections;

namespace Forest {

public class SchoolgirlController : MonoBehaviour {
	private Animator animator;
	public delegate void SchoolgirlAction();
	public static event SchoolgirlAction OnFinishedWalking;

	private IEnumerator initialWalk() {
		animator.SetInteger("Walking", 1);
		yield return new WaitForSeconds(2);
		animator.SetInteger("Walking", 0);
		yield return new WaitForSeconds(2);
		if (OnFinishedWalking != null) {
			OnFinishedWalking();
		}
	}

	private void onFinished() {
		animator.SetInteger("Jumping", 1);
	}

	private void OnEnable() {
		DialogueTextController.OnFinished += onFinished;
	}

	private void OnDisable() {
		DialogueTextController.OnFinished -= onFinished;
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

}
