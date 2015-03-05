using UnityEngine;
using System.Collections;

namespace Village
{
    public class InvisibleWallController : MonoBehaviour
    {
        private GameObject invisibleBox;

        private IEnumerator loadNewLevel()
        {
            invisibleBox.SendMessage("FadeOut");
            yield return new WaitForSeconds(2);
            // load second scene
            Application.LoadLevel(1);
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == "FPSGirl")
            {
                StartCoroutine(loadNewLevel());
            }
        }

        // Use this for initialization
        void Start()
        {
            invisibleBox = GameObject.Find("InvisibleBox");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
