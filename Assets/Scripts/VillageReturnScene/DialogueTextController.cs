using UnityEngine;
using System.Collections;

namespace VillageReturn
{
	public class DialogueTextController : MonoBehaviour 
	{
		private GameObject objectiveText;

		private IEnumerator startDialogue()
		{
			this.guiText.text = "3 hours later....";
			yield return new WaitForSeconds(5);
			this.guiText.text = "Girl: What's going on here? Why is this place flooded with porridge?";
			yield return new WaitForSeconds(3);
			this.guiText.text = "Mom (in the distance): I forgot how to stop the porridge :( halp!";
			yield return new WaitForSeconds(3);
			this.guiText.text = "Girl: *facepalm*";
			yield return new WaitForSeconds(3);
			this.guiText.text = "Looters: Yay! Its hurricane porridge! Lets take other people's stuff! :3";
			yield return new WaitForSeconds(4);
			this.guiText.text = "";
			objectiveText.guiText.text = "Objective: Avoid the looters and get to the house";
		}

		// Use this for initialization
		void Start () 
		{
			this.guiText.text = "";
			objectiveText = GameObject.Find("DialogueText");
			objectiveText.guiText.text = "";
			StartCoroutine(startDialogue());
		}
		
		// Update is called once per frame
		void Update () 
		{
		
		}
	}
}
