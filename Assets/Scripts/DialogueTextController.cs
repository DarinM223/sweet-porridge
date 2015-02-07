using UnityEngine;
using System.Collections;

public class DialogueTextController : MonoBehaviour {

	void afterTitleCameraFinished() {
		this.guiText.text = "HEY BUCKYY!!";
	}

	void OnEnable() {
		TitleCameraController.OnFinishedZooming += afterTitleCameraFinished;
	}

	void OnDisable() {
		TitleCameraController.OnFinishedZooming -= afterTitleCameraFinished;
	}

	// Use this for initialization
	void Start () {
		this.guiText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
