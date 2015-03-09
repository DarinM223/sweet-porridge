using UnityEngine;
using System.Collections;

namespace VillageReturn 
{
	public class DoorController : MonoBehaviour 
	{

		private GameObject invisibleBox;

		private IEnumerator loadNewLevel()
		{
			invisibleBox.SendMessage("FadeOut");
			// end level
			yield return new WaitForSeconds(2);
		}

		void OnCollisionEnter(Collision col)
		{
			if (col.gameObject.name == "FPSGirl") 
			{
				StartCoroutine(loadNewLevel());
			}
		}

		// Use this for initialization
		void Start () 
		{
			invisibleBox = GameObject.Find("InvisibleBox");
		}

		// Update is called once per frame
		void Update () 
		{
		
		}
	}
}


