using UnityEngine;
using System.Collections;

namespace VillageReturn 
{
	public class SchoolgirlController : MonoBehaviour 
	{
		private GameObject dialogueText;

		void OnCollisionEnter(Collision col) 
		{
			if (col.gameObject.name == "NPCOne" || col.gameObject.name == "NPCTwo" || col.gameObject.name == "NPCThree")
			{
				dialogueText.guiText.text = "RIP porridge girl 2015";
				dialogueText.guiText.color = Color.red;
				Application.LoadLevel(3);
			}
		}

		// Use this for initialization
		void Start () 
		{
			dialogueText = GameObject.Find("DialogueText");
		}
		
		// Update is called once per frame
		void Update ()
	   	{
		
		}
	}
}
