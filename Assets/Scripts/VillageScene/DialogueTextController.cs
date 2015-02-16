using UnityEngine;
using System.Collections;

namespace Village {

public class DialogueTextController : MonoBehaviour {

	void afterTitleCameraFinished() {
		this.guiText.text = "[hunger intensifies]";
	}

	void afterGirlRotated() {
		this.guiText.text = "Mom: We are out of food... We won't survive much longer";
	}

	void afterMomTalked() {
		this.guiText.text = "Girl: I'll go into the forest and try to get some food"; 
	}

	void afterGirlTalked() {
		this.guiText.text = "";
	}

	void OnEnable() {
		TitleCameraController.OnFinishedZooming += afterTitleCameraFinished;
		SchoolgirlController.OnFinishedRotating += afterGirlRotated;
		SchoolgirlController.OnFinishedTalking += afterGirlTalked;
		MomController.OnFinishedTalking += afterMomTalked;
	}

	void OnDisable() {
		TitleCameraController.OnFinishedZooming -= afterTitleCameraFinished;
		SchoolgirlController.OnFinishedRotating += afterGirlRotated;
		SchoolgirlController.OnFinishedTalking -= afterGirlTalked;
		MomController.OnFinishedTalking -= afterMomTalked;
	}

	// Use this for initialization
	void Start () {
		this.guiText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

	}
}

}
