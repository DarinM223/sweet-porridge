using UnityEngine;
using System.Collections;

public class InvisibleWallController : MonoBehaviour {

	private GameObject invisibleBox;

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "FPSGirl") {
			invisibleBox.SendMessage("fadeOut");
			// load second scene
		}
	}

	// Use this for initialization
	void Start () {
		invisibleBox = GameObject.Find("InvisibleBox");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
