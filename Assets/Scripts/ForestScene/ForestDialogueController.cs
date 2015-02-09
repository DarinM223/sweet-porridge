using UnityEngine;
using System.Collections;

public class ForestDialogueController : MonoBehaviour {

	private IEnumerator doDialogue() {
		yield return new WaitForSeconds(4);
		this.guiText.text = "cook, little pot, cook";
		yield return new WaitForSeconds(8);
		this.guiText.text = "stop, little pot, stop";
		yield return new WaitForSeconds(6);
		this.guiText.text = "You can have this pot";
	}

	private void afterGirlWalked() {
		this.guiText.text = "This pot can cook an infinite amount of porridge";
		StartCoroutine(doDialogue());
	}

	void OnEnable() {
		ForestSchoolgirlController.OnFinishedWalking += afterGirlWalked;
	}

	void OnDisable() {
		ForestSchoolgirlController.OnFinishedWalking -= afterGirlWalked;
	}

	// Use this for initialization
	void Start () {
		this.guiText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
