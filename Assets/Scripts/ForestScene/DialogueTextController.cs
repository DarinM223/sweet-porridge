using UnityEngine;
using System.Collections;

namespace Forest
{
    public class DialogueTextController : MonoBehaviour
    {
        public delegate void DialogueAction();
        public static event DialogueAction OnWoot;

        private GameObject theEnd;
        private GameObject invisibleCube;

        private IEnumerator doDialogue()
        {
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
            if (OnWoot != null)
            {
                OnWoot();
            }
            yield return new WaitForSeconds(4);
            // MoveScripts.HideObject(theEnd, false);
        }

        private void afterGirlWalked()
        {
            this.guiText.text = "Girl: Do you have any food to spare? My mom and I are starving";
            StartCoroutine(doDialogue());
        }

        private IEnumerator loadNewLevel()
        {
            yield return new WaitForSeconds(2);
            // load third level
        }

        private void onFinishLevel()
        {
            invisibleCube.SendMessage("FadeOut");
            StartCoroutine(loadNewLevel());
        }

        void OnEnable()
        {
            SchoolgirlController.OnFinishedWalking += afterGirlWalked;
            SchoolgirlController.OnFinishedExiting += onFinishLevel;
        }

        void OnDisable()
        {
            SchoolgirlController.OnFinishedWalking -= afterGirlWalked;
            SchoolgirlController.OnFinishedExiting -= onFinishLevel;
        }

        // Use this for initialization
        void Start()
        {
            theEnd = GameObject.Find("TheEnd");
            invisibleCube = GameObject.Find("InvisibleCube");
            MoveScripts.HideObject(theEnd, true);
            this.guiText.text = "";
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
