﻿using UnityEngine;
using System.Collections;

public class WalkingGirlCameraController : MonoBehaviour {

	private bool cameraMoving = false;

	void afterFadeIn() {
		cameraMoving = true;
	}

	void afterFinishedWalking() {
		cameraMoving = false;
	}

	void OnEnable() {
		SchoolgirlController.OnFinishedFadeIn += afterFadeIn;
		SchoolgirlController.OnFinishedWalking += afterFinishedWalking;
	}

	void OnDisable() {
		SchoolgirlController.OnFinishedFadeIn -= afterFadeIn;
		SchoolgirlController.OnFinishedWalking -= afterFinishedWalking;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraMoving) {
			// move camera
			this.transform.Translate(this.transform.forward * -10 * Time.deltaTime);
		}
	}
}
