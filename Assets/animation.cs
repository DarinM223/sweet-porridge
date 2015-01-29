using UnityEngine;
using System.Collections;

public class animation : MonoBehaviour {

	private RaycastHit hit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// transform.Translate (transform.forward);
		// Debug.DrawRay (transform.position, transform.forward * 100, Color.blue);
		if (Physics.Raycast (transform.position, transform.forward, out hit, 100)) {
			print ("There is a " + hit.transform.name + " directly ahead");
		} else {
			print ("There is nothing directly ahead");
		}
	}
}
