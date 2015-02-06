using UnityEngine;
using System.Collections;

public class TitleCameraController : MonoBehaviour {

	public delegate void TitleCameraAction();
	public static event TitleCameraAction OnFinishedZooming;

	private GameObject girl; // the protagonist of the story
	private GameObject title; // game title shown in the sky at the beginning of the scene
	private Camera mainCamera;
	private Time startTime;
	private bool started;
	private bool rotating;
	private bool zooming;

	// Use this for initialization
	void Start () {
		girl = GameObject.Find("Schoolgirl");
		title = GameObject.Find("Title");
		mainCamera = GameObject.Find("MainCamera").camera;
		mainCamera.enabled = false;
		started = true;
		rotating = false;
		zooming = false;
	}

	private IEnumerator waitForSpecifiedTime() {
		yield return new WaitForSeconds(3);
		MoveScripts.HideObject(title, true);
		yield return new WaitForSeconds(2);
		started = false;
		rotating = true;
	}

	private IEnumerator rotateToGirl() {
		Quaternion rotTrans = MoveScripts.RotateToFace(this.transform, girl.transform);
		if ((rotTrans.eulerAngles - transform.rotation.eulerAngles).sqrMagnitude < .0001) {
			yield return new WaitForSeconds(1);
			rotating = false;
			zooming = true;
		} else if (rotating) {
			this.transform.rotation = rotTrans;
		}
	}

	private IEnumerator zoomToGirl() {
		float distance = Vector3.Distance(this.transform.position, girl.transform.position);
		if (distance > 7.0) {
			transform.position += transform.forward * Time.deltaTime * 20;
		} else {
			yield return new WaitForSeconds(2);

			if (OnFinishedZooming != null) {
				OnFinishedZooming(); // call event after finishing
			}
			zooming = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (started) {
			StartCoroutine(waitForSpecifiedTime());
		} else if (rotating) {
			StartCoroutine(rotateToGirl());
		} else if (zooming) {
			StartCoroutine(zoomToGirl());
		} else {
			this.enabled = false;
		}
	}
}
