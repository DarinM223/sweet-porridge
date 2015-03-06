using UnityEngine;
using System.Collections;

namespace Forest
{
    public class SchoolgirlController : MonoBehaviour
    {
        private Animator animator;
        public delegate void SchoolgirlAction();
        public static event SchoolgirlAction OnFinishedWalking;
        public static event SchoolgirlAction OnPickedUpPot;
        public static event SchoolgirlAction OnFinishedExiting;

        private GameObject backwardsCube;
        private bool rotating = false;
        private bool finishedRotating = false;

        private IEnumerator initialWalk()
        {
            animator.SetInteger("Walking", 1);
            yield return new WaitForSeconds(2);
            animator.SetInteger("Walking", 0);
            yield return new WaitForSeconds(2);

            if (OnFinishedWalking != null)
            {
                OnFinishedWalking();
            }
        }

        private IEnumerator finalWalk()
        {
            animator.SetInteger("Walking", 1);
            yield return new WaitForSeconds(2);
            animator.SetInteger("Walking", 0);

            if (OnFinishedExiting != null)
            {
                OnFinishedExiting();
            }
        }

        private IEnumerator pickUpPot()
        {
            animator.SetInteger("PickUp", 1);
            yield return new WaitForSeconds(2);

            if (OnPickedUpPot != null)
            {
                OnPickedUpPot();
            }

            yield return new WaitForSeconds(1);

            animator.SetInteger("PickUp", 0);
            this.rotating = true;
        }

        private IEnumerator jump()
        {
            animator.SetInteger("Jumping", 1);
            yield return new WaitForSeconds(4);
            animator.SetInteger("Jumping", 0);
            StartCoroutine(pickUpPot());
        }

        private void onWoot()
        {
            StartCoroutine(jump());
        }

        private void OnEnable()
        {
            DialogueTextController.OnWoot += onWoot;
        }

        private void OnDisable()
        {
            DialogueTextController.OnWoot -= onWoot;
        }

        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
            backwardsCube = GameObject.Find("BackwardsCube");
            StartCoroutine(initialWalk());
        }

        // Update is called once per frame
        void Update()
        {
            if (this.rotating)
            {
                Quaternion rotTrans = MoveScripts.RotateToFace(this.transform, backwardsCube.transform.position);

                if ((rotTrans.eulerAngles - transform.rotation.eulerAngles).sqrMagnitude < .01)
                {
                    if (this.finishedRotating == false)
                    {
                        this.finishedRotating = true;
                        this.rotating = false;
                        StartCoroutine(finalWalk());
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
