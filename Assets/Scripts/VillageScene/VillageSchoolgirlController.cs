using UnityEngine;
using System.Collections;

public class VillageSchoolgirlController : MonoBehaviour {

	public delegate void SchoolgirlAction();
	public static event SchoolgirlAction OnFinishedRotating;
	public static event SchoolgirlAction OnFinishedTalking;
	public static event SchoolgirlAction OnFinishedRotate180;
	public static event SchoolgirlAction OnFinishedFadeIn;
	public static event SchoolgirlAction OnFinishedWalking;

	private RaycastHit hit;
	private GameObject mom;
	private GameObject pot;
	private GameObject invisibleBox;
	private GameObject fpsGirl;

	private Camera girlCamera;

	private Animator animator;
	private int walkingState;
	private int strafeState;
	private int rotateState;

	private bool facingForward = true;
	private bool rotating = false;
	private bool rotating180 = false;
	private bool finishedRotating = false;
	private bool finishedRotating180 = false;
	private bool walking = false;

	private void afterTitleCameraFinished() {
		this.rotating = true;
	}

	private IEnumerator doTalking() {
		yield return new WaitForSeconds(3);
		if (OnFinishedTalking != null) {
			OnFinishedTalking();
			this.rotating180 = true;
		}
	}

	private void afterMomTalked() {
		StartCoroutine(doTalking());
	}

	void OnEnable() {
		TitleCameraController.OnFinishedZooming += afterTitleCameraFinished;
		MomController.OnFinishedTalking += afterMomTalked;
	}

	void OnDisable() {
		TitleCameraController.OnFinishedZooming -= afterTitleCameraFinished;
		MomController.OnFinishedTalking -= afterMomTalked;
	}

	// Use this for initialization
	void Start () {
		mom = GameObject.Find("Mom");
		pot = GameObject.Find ("Pot");
		invisibleBox = GameObject.Find("InvisibleBox");
		fpsGirl = GameObject.Find("FPSGirl");
		fpsGirl.active = false;
		girlCamera = GameObject.Find("GirlCamera").camera;
		animator = GetComponent<Animator> ();
	}

	private void raycast() {
		if (Physics.Raycast (transform.position, transform.forward, out hit, 100)) {
			if (hit.transform.name != "Terrain") {
				print ("Saw a " + hit.transform.name);
			}
		}
	}

	private void processWalk() {
		animator.SetInteger("Walking", walkingState);
		animator.speed = Mathf.Abs(walkingState);
		if (walkingState < 0 && facingForward) {
			transform.forward *= -1;
			facingForward = false;
		}

		if (walkingState > 0 && !facingForward) {
			transform.forward *= -1;
			facingForward = true;
		}
	}

	private void clearWalk() {
		walkingState = 0;
		animator.SetInteger("Walking", 0);
	}

	private void processStrafe() {
		animator.SetInteger("Strafing", strafeState);
		animator.speed = Mathf.Abs(strafeState);
	}

	private void clearStrafe() {
		strafeState = 0;
		animator.SetInteger("Strafing", 0);
	}

	private void rotationCoroutine() {
		if (OnFinishedRotating != null) {
			OnFinishedRotating(); // call event after finishing
		}
	}

	private IEnumerator strafeWalk() {
		animator.SetInteger("Strafing", -1);
		yield return new WaitForSeconds(2);
		animator.SetInteger("Strafing", 0);
		animator.SetInteger("Walking", 1);
		yield return new WaitForSeconds(1);
		animator.SetInteger("Walking", 0);
		invisibleBox.SendMessage("fadeOut");
		yield return new WaitForSeconds(2);
		fpsGirl.active = true;
		invisibleBox.SendMessage("fadeIn");
	}

	// Update is called once per frame
	void Update () {
		if (this.rotating) {
			Quaternion rotTrans = MoveScripts.RotateToFace(this.transform, mom.transform.position);
			if ((rotTrans.eulerAngles - transform.rotation.eulerAngles).sqrMagnitude < .0001) {
				if (this.finishedRotating == false) {
					this.finishedRotating = true;
					this.rotating = false;
					rotationCoroutine();
				}
			} else {
				this.transform.rotation = rotTrans;
			}
		} else if (this.rotating180) {
			Quaternion rotTrans = MoveScripts.RotateToFace(this.transform, invisibleBox.transform.position);
			if ((rotTrans.eulerAngles - transform.rotation.eulerAngles).sqrMagnitude < .0001) {
				if (this.finishedRotating180 == false) {
					this.finishedRotating180 = true;
					this.rotating180 = false;
					StartCoroutine(strafeWalk());
				}
			} else {
				this.transform.rotation = rotTrans;
			}
		}
	}
}
