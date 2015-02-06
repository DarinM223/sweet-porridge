using UnityEngine;
using System.Collections;

public class SchoolgirlController : MonoBehaviour {

	private RaycastHit hit;
	private GameObject oldWoman;
	private GameObject pot;
	private Camera camera;

	private bool stoppedInFrontOfWoman;
	private bool sawPot;

	private Animator animator;
	private int walkingState;
	private int strafeState;

	private int rotateState;

	private bool facingForward = true;

	// Use this for initialization
	void Start () {
		oldWoman = GameObject.Find ("Old_Ass_Woman");
		camera = GameObject.Find ("MainCamera").camera;
		pot = GameObject.Find ("Pot");
		animator = GetComponent<Animator> ();
		stoppedInFrontOfWoman = false;
		sawPot = false;
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


	// Update is called once per frame
	void Update () {
		var dist = Vector3.Distance(oldWoman.transform.position, transform.position);

		// raycast ();

		float walkingSpeed = Input.GetAxis("Vertical");

		if (walkingSpeed > 0) {
			walkingState = (int)walkingSpeed+1;
		} else if (walkingSpeed < 0) {
			walkingState = (int)walkingSpeed-1;
		} else {
			walkingState = 0;
		}

		if (walkingState != 0) {
			processWalk();
		} else {
			clearWalk();
		}

		float rotateSpeed = Input.GetAxis("Horizontal");

		if (rotateSpeed > 0) {
			strafeState = (int)rotateSpeed+1;
		} else if (rotateSpeed < 0) {
			strafeState = (int)rotateSpeed-1;
		} else {
			strafeState = 0;
		}

		if (strafeState != 0) {
			processStrafe();
		} else {
			clearStrafe();
		}

		if (!Input.anyKey) {
			clearWalk();
			clearStrafe();
		}
	}
}
