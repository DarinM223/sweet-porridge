using UnityEngine;
using System.Collections;

namespace Forest {

public class DialogueTextController : MonoBehaviour {
	public delegate void DialogueAction();
	public static event DialogueAction OnFinished;

	private GameObject theEnd;

	private IEnumerator doDialogue() {
		yield return new WaitForSeconds(4);
		this.guiText.text = "Old woman: Actually I happen to have a pot that cooks an infinite amount of porridge";
		yield return new WaitForSeconds(5);
		this.guiText.text = "Old woman: Watch this";
		yield return new WaitForSeconds(3);
		this.guiText.text = "Old woman: cook, little pot, cook";
		yield return new WaitForSeconds(8);
		this.guiText.text = "Old woman: stop, little pot, stop";
		yield return new WaitForSeconds(6);
		this.guiText.text = "Old woman: You can have this pot of course I have an extra one ( ͡° ͜ʖ ͡°)";
		yield return new WaitForSeconds(4);
		this.guiText.text = "Girl: W0000TTT!!!";
		if (OnFinished != null) {
			OnFinished();
		}
		yield return new WaitForSeconds(4);
		MoveScripts.HideObject(theEnd, false);
	}

	private void afterGirlWalked() {
		this.guiText.text = "Girl: Do you have any food to spare? My mom and I are starving";
		StartCoroutine(doDialogue());
	}

	void OnEnable() {
		SchoolgirlController.OnFinishedWalking += afterGirlWalked;
	}

	void OnDisable() {
		SchoolgirlController.OnFinishedWalking -= afterGirlWalked;
	}

	// Use this for initialization
	void Start () {
		theEnd = GameObject.Find("TheEnd");
		MoveScripts.HideObject(theEnd, true);
		this.guiText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

}
