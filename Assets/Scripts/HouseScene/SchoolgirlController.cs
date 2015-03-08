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

		private GameObject doorCube;
		private bool rotating = false;
		private bool finishedRotating = false;

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
			animator.SetInteger("Walking", 1);
			yield return new WaitForSeconds(3);
			animator.SetInteger("Walking", 0);
			yield return new WaitForSeconds(2);

			if (OnFinishedExiting != null) 
			{
				OnFinishedExiting();
			}
		}

		private void onFinishedDialogue() 
		{
			this.rotating = true;
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
			doorCube = GameObject.Find("DoorCube");
			StartCoroutine(walk());
		}
		
		// Update is called once per frame
		void Update () 
		{
            if (this.rotating)
            {
                Quaternion rotTrans = MoveScripts.RotateToFace(this.transform, doorCube.transform.position);

                if ((rotTrans.eulerAngles - transform.rotation.eulerAngles).sqrMagnitude < .01)
                {
                    if (this.finishedRotating == false)
                    {
                        this.finishedRotating = true;
                        this.rotating = false;
                        StartCoroutine(walkAway());
                    }
                }
                else
                {
                    this.transform.rotation = rotTrans;
                }
            }
		}
	}
}
