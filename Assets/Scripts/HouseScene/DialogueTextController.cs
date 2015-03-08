using UnityEngine;
using System.Collections;

namespace House
{
    public class DialogueTextController : MonoBehaviour
    {
    	public delegate void DialogueAction();
    	public static event DialogueAction OnFinishedDialogue;
    	public static event DialogueAction OnStartPot;

    	private GameObject exclamationSign;
    	private GameObject invisibleCube;

    	private IEnumerator startDialogue()
    	{
    		this.guiText.text = "Girl: I brought home a pot that cooks an infinite amount of porridge";
    		yield return new WaitForSeconds(3);
    		this.guiText.text = "Girl: Now we will never get hungry again";
    		yield return new WaitForSeconds(5);
    		this.guiText.text = "Mom: ^_^";
    		yield return new WaitForSeconds(4);
    		this.guiText.text = "Girl: You start the pot by saying \"start, pot, start\" and you stop the pot with -";
    		
    		yield return new WaitForSeconds(2);
    		exclamationSign.active = true;
    		yield return new WaitForSeconds(3);

    		this.guiText.text = "Girl: OMG Snow White just tweeted that she is awake I have to see brb lol";
    		yield return new WaitForSeconds(3); 		

    		if (OnFinishedDialogue != null) 
    		{
    			OnFinishedDialogue();
    		}
    	}

    	private IEnumerator resumeDialogue()
    	{
    		this.guiText.text = "Mom: I guess I better start making the porridge";
    		yield return new WaitForSeconds(3);
    		this.guiText.text = "Mom: start, pot, start";
    		yield return new WaitForSeconds(3);

    		if (OnStartPot != null) 
    		{
    			OnStartPot();
    		}

    		yield return new WaitForSeconds(4);

    		invisibleCube.SendMessage("FadeOut");
    	}

    	private void onSchoolgirlFinishedWalking() 
    	{
    		StartCoroutine(startDialogue());
    	}

    	void OnEnable() 
        {
			SchoolgirlController.OnFinishedWalking += onSchoolgirlFinishedWalking;
        }

        void OnDisable()
        {
        	SchoolgirlController.OnFinishedWalking -= onSchoolgirlFinishedWalking;
        }

        // Use this for initialization
        void Start()
        {
        }
	
        // Update is called once per frame
        void Update()
        {
        }
    }
}

