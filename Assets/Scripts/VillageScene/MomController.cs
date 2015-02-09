using UnityEngine;
using System.Collections;

public class MomController : MonoBehaviour {
	public delegate void MomAction();
	public static event MomAction OnFinishedTalking; 
	
	private bool isTalking = false;

	IEnumerator wait() {
		yield return new WaitForSeconds(6);
		this.isTalking = false;
		if (OnFinishedTalking != null) {
			OnFinishedTalking(); // call event after waiting
		}
	}

	void afterGirlRotated() {
		this.isTalking = true;
		StartCoroutine(wait());
	}

	void OnEnable() {
		VillageSchoolgirlController.OnFinishedRotating += afterGirlRotated;
	}

	void OnDisable() {
		VillageSchoolgirlController.OnFinishedRotating -= afterGirlRotated;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isTalking) {
			// play talking animation
		}
	}
}
