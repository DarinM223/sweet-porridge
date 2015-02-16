using UnityEngine;
using System.Collections;

namespace Village {

public class MomCameraController : MonoBehaviour {
	private Camera girlCamera;

	void afterMomTalked() {
		this.camera.active = false;
		girlCamera.active = true;
	}

	void OnEnable() {
		MomController.OnFinishedTalking += afterMomTalked;
	}

	void OnDisable() {
		MomController.OnFinishedTalking -= afterMomTalked;
	}

	// Use this for initialization
	void Start () {
		girlCamera = GameObject.Find("GirlCamera").camera;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

}
