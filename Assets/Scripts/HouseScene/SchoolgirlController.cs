using UnityEngine;
using System.Collections;

namespace House 
{
	public class SchoolgirlController : MonoBehaviour 
	{
		private Animator animator;
		public delegate void SchoolgirlAction();
		public static event SchoolgirlAction OnFinishedWalking;
		public static event SchoolgirlAction OnFinishedExiting;

		private IEnumerator walkAway() 
		{
			yield return new WaitForSeconds(2);
		}

		private void onFinishedDialogue() 
		{
			StartCoroutine(walkAway());
		}

		void OnEnable()
		{
			DialogueTextController.OnFinishedDialogue += onFinishedDialogue;
		}

		void OnDisable()
		{
			DialogueTextController.OnFinishedDialogue -= onFinishedDialogue;
		}

		// Use this for initialization
		void Start () 
		{
			animator = GetComponent<Animator>();

		}
		
		// Update is called once per frame
		void Update () 
		{
		
		}
	}
}
