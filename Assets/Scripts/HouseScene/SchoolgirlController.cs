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

		private IEnumerator walk() 
		{
			animator.SetInteger("Walking", 1);
			yield return new WaitForSeconds(3);
			animator.SetInteger("Walking", 0);
			yield return new WaitForSeconds(3);

			if (OnFinishedWalking != null) 
			{
				OnFinishedWalking();
			}
		}

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
			StartCoroutine(walk());
		}
		
		// Update is called once per frame
		void Update () 
		{
		
		}
	}
}
