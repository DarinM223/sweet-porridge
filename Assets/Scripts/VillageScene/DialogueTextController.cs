using UnityEngine;
using System.Collections;

public class DialogueTextController : MonoBehaviour {

	void afterTitleCameraFinished() {
		this.guiText.text = "HEY BUCKYY!!";
	}

	void afterGirlRotated() {
		this.guiText.text = "There is no more food left. Go outside and try to find some delicious porridge";
	}

	void afterMomTalked() {
		this.guiText.text = "kk";
	}

	void afterGirlTalked() {
		this.guiText.text = "";
	}

	void OnEnable() {
		TitleCameraController.OnFinishedZooming += afterTitleCameraFinished;
		VillageSchoolgirlController.OnFinishedRotating += afterGirlRotated;
		VillageSchoolgirlController.OnFinishedTalking += afterGirlTalked;
		MomController.OnFinishedTalking += afterMomTalked;
	}

	void OnDisable() {
		TitleCameraController.OnFinishedZooming -= afterTitleCameraFinished;
		VillageSchoolgirlController.OnFinishedRotating += afterGirlRotated;
		VillageSchoolgirlController.OnFinishedTalking -= afterGirlTalked;
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
