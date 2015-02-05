using UnityEngine;
using System.Collections;

public class animation : MonoBehaviour {

	private RaycastHit hit;
	private GameObject oldWoman;
	private GameObject pot;
	private Camera camera;

	private bool stoppedInFrontOfWoman;
	private bool sawPot;

	private Animator animator;
	private int walkingState = 0;
	private int rotateState = 0;

	// Use this for initialization
	void Start () {
		oldWoman = GameObject.Find ("Old_Ass_Woman");
		camera = GameObject.Find ("MainCamera").camera;
		pot = GameObject.Find ("Pot");
		animator = this.GetComponent<Animator> ();
		stoppedInFrontOfWoman = false;
		sawPot = false;
	}

	void raycast() {
		if (Physics.Raycast (transform.position, transform.forward, out hit, 100)) {
			if (hit.transform.name != "Terrain") {
				print ("Saw a " + hit.transform.name);
			}
		} else {
		}
	}

	void processWalk(int direction) {
		print (direction);
		if (walkingState != 0) return;

		walkingState = 1;
		animator.speed = direction;
		animator.SetInteger ("Walking", walkingState);
	}

	void clearWalk() {
		walkingState = 0;
		animator.SetInteger("Walking", walkingState);
	}

	void processRotate(int direction) {
		print(direction);
		if (rotateState != 0) return;

		rotateState = direction;
		if (direction <= -1) {
			animator.SetInteger("LeftTurn", 1);
		} else if (direction >= 1) {
			animator.SetInteger("RightTurn", 1);
		}
	}

	void clearRotate() {
		rotateState = 0;
		animator.SetInteger("LeftTurn", rotateState);
		animator.SetInteger("RightTurn", rotateState);
	}

	void clearEverything() {
		clearWalk();
		clearRotate();
	}

	// Update is called once per frame
	void Update () {
		var dist = Vector3.Distance (oldWoman.transform.position, transform.position);

		raycast ();

		if (Input.GetAxis("Vertical") != 0)  
			processWalk((int)((Input.GetAxis("Vertical") > 0 ? Input.GetAxis("Vertical")+1 : Input.GetAxis("Vertical") - 1)));
		else
			clearWalk();

		print(Input.GetAxis("Horizontal"));

		if (Input.GetAxis("Horizontal") != 0) 
			processRotate((int)((Input.GetAxis("Horizontal") > 0 ? Input.GetAxis("Horizontal")+1 : Input.GetAxis("Horizontal") - 1)));
		else 
			clearRotate();

		if (!Input.anyKey) clearEverything();

		// rotate to face old woman
//		Quaternion targetRotation;
//		if (stoppedInFrontOfWoman) {
//			targetRotation = Quaternion.LookRotation (pot.transform.position - transform.position);
//		} else {
//			targetRotation = Quaternion.LookRotation (oldWoman.transform.position - transform.position);
//		}
//		var str = Mathf.Min (1 * Time.deltaTime, 1);
//		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);
//
//		// move until close to old woman
//		if (dist > 5 && !stoppedInFrontOfWoman) {
//			animator.SetInteger("Walking", 1);
//			camera.transform.Translate(transform.forward * -1 * Time.deltaTime);
//			camera.transform.LookAt(this.transform.position);
//		} else {
//			if (!stoppedInFrontOfWoman) {
//				animator.SetInteger("Walking", 0);
//				print ("Stopped in front of old woman!");
//				stoppedInFrontOfWoman = true;
//			}
//		}
	}
}
