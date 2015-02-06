using UnityEngine;
using System.Collections;

public class TitleCameraController : MonoBehaviour {

	private GameObject trailerHouse; // the house where the girl lives
	private GameObject title; // game title shown in the sky at the beginning of the scene
	private Time startTime;
	private bool started;

	// Use this for initialization
	void Start () {
		trailerHouse = GameObject.Find("TrailerHouse");
		title = GameObject.Find("Title");
		started = true;
	}

	private IEnumerator waitForSpecifiedTime() {
		yield return new WaitForSeconds(3);
		MoveScripts.HideObject(title, true);
		yield return new WaitForSeconds(2);
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
