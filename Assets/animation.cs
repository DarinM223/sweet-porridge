using UnityEngine;
using System.Collections;

public class animation : MonoBehaviour {

	private RaycastHit hit;
	private GameObject oldWoman;
	private GameObject pot;

	private bool stoppedInFrontOfWoman;
	private bool sawPot;

	// Use this for initialization
	void Start () {
		oldWoman = GameObject.Find ("Old_Ass_Woman");
		pot = GameObject.Find ("Pot");
		stoppedInFrontOfWoman = false;
		sawPot = false;
	}
	
	// Update is called once per frame
	void Update () {
		var dist = Vector3.Distance (oldWoman.transform.position, transform.position);

		if (Physics.Raycast (transform.position, transform.forward, out hit, 100)) {
			if (hit.transform.name != "Terrain") {
				if (hit.transform.name == "Pot") {
					if (!sawPot) {
						print ("Saw a " + hit.transform.name);
						sawPot = true;
					}
				}
			}
		} else {
		}

		// rotate to face old woman
		Quaternion targetRotation;
		if (stoppedInFrontOfWoman) {
			targetRotation = Quaternion.LookRotation (pot.transform.position - transform.position);
		} else {
			targetRotation = Quaternion.LookRotation (oldWoman.transform.position - transform.position);
		}
//		targetRotation = Quaternion.LookRotation (oldWoman.transform.position - transform.position);
		var str = Mathf.Min (1 * Time.deltaTime, 1);
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);

		// move until close to old woman
		if (dist > 5) {
			transform.Translate(transform.forward * -3 * Time.deltaTime);
		} else {
			if (!stoppedInFrontOfWoman) {
				print ("Stopped in front of old woman!");
				stoppedInFrontOfWoman = true;
			}
		}
	}
}
