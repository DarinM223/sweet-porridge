using UnityEngine;
using System.Collections;

namespace Forest
{
    public class PotController : MonoBehaviour
    {
        private GameObject cookingSteam;
        private GameObject porridgeCooking;

        private IEnumerator doCookCoroutine()
        {
            yield return new WaitForSeconds(14);
            cookingSteam.active = true;
            porridgeCooking.active = true;
            yield return new WaitForSeconds(10);
            cookingSteam.active = false;
            porridgeCooking.active = false;
        }

        private void removePot()
        {
            this.active = false;
        }

        private void afterGirlWalked()
        {
            StartCoroutine(doCookCoroutine());
        }

        void OnEnable()
        {
            SchoolgirlController.OnFinishedWalking += afterGirlWalked;
            SchoolgirlController.OnPickedUpPot += removePot;
        }

        void OnDisable()
        {
            SchoolgirlController.OnFinishedWalking -= afterGirlWalked;
            SchoolgirlController.OnPickedUpPot -= removePot;
        }

        // Use this for initialization
        void Start()
        {
            cookingSteam = GameObject.Find("CookingSteam");
            porridgeCooking = GameObject.Find("PorridgeCooking");
            cookingSteam.active = false;
            porridgeCooking.active = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
