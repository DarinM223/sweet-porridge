using UnityEngine;
using System.Collections;

public class TitleCameraController : MonoBehaviour {

	private GameObject trailerHouse;
	private Time startTime;
	private bool started;

	// Use this for initialization
	void Start () {
		trailerHouse = GameObject.Find("TrailerHouse");
		started = true;
	}

	private IEnumerator waitForSpecifiedTime() {
		yield return new WaitForSeconds(4);
		started = false;
	}

	// Update is called once per frame
	void Update () {
		if (started) {
			StartCoroutine(waitForSpecifiedTime());
		} else {
			MoveScripts.RotateToFace(this.transform, trailerHouse.transform);
		}
	}
}
