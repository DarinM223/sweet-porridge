using UnityEngine;
using System.Collections;

namespace House
{
    public class DialogueTextController : MonoBehaviour
    {
    	public delegate void DialogueAction();
    	public static event DialogueAction OnFinishedDialogue;

    	private GameObject exclamationTop;
    	private GameObject exclamationBot;
    	private GameObject invisibleCube;
    	private GameObject cookingPot;
    	private GameObject cookingSteam;
    	private GameObject porridgeCooking;

    	private IEnumerator startDialogue()
    	{
    		MoveScripts.HideObject(this.cookingPot, false);
    		this.guiText.text = "Girl: I brought home a pot that cooks an infinite amount of porridge";
    		yield return new WaitForSeconds(3);
    		this.guiText.text = "Girl: Now we will never get hungry again";
    		yield return new WaitForSeconds(5);
    		this.guiText.text = "Mom: ^_^";
    		yield return new WaitForSeconds(4);
    		this.guiText.text = "Girl: You start the pot by saying \"start, pot, start\" and you stop the pot with -";
    		yield return new WaitForSeconds(2);
    		MoveScripts.HideObject(exclamationBot, false);
        	MoveScripts.HideObject(exclamationTop, false);
    		yield return new WaitForSeconds(3);
    		MoveScripts.HideObject(exclamationBot, true);
        	MoveScripts.HideObject(exclamationTop, true);

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

    		cookingSteam.active = true;
    		porridgeCooking.active = true;

    		yield return new WaitForSeconds(4);

    		invisibleCube.SendMessage("FadeOut");
    	}

    	private void onSchoolgirlFinishedWalking() 
    	{
    		StartCoroutine(startDialogue());
    	}

    	private void onSchoolgirlFinishedExiting() 
    	{
    		StartCoroutine(resumeDialogue());
    	}

    	void OnEnable() 
        {
			SchoolgirlController.OnFinishedWalking += onSchoolgirlFinishedWalking;
			SchoolgirlController.OnFinishedExiting += onSchoolgirlFinishedExiting;
        }

        void OnDisable()
        {
        	SchoolgirlController.OnFinishedWalking -= onSchoolgirlFinishedWalking;
        	SchoolgirlController.OnFinishedExiting -= onSchoolgirlFinishedExiting;
        }

        // Use this for initialization
        void Start()
        {
        	this.guiText.text = "";
        	this.exclamationTop = GameObject.Find("ExclamationTop");
        	this.exclamationBot = GameObject.Find("ExclamationBot");
        	this.invisibleCube = GameObject.Find("InvisibleCube");
        	this.cookingPot = GameObject.Find("CookingPot");
        	this.cookingSteam = GameObject.Find("CookingSteam");
        	this.porridgeCooking = GameObject.Find("PorridgeCooking");

        	this.exclamationBot.renderer.material.color = Color.yellow;
        	this.exclamationTop.renderer.material.color = Color.yellow;

        	MoveScripts.HideObject(exclamationBot, true);
        	MoveScripts.HideObject(exclamationTop, true);
        	MoveScripts.HideObject(cookingPot, true);
        	cookingSteam.active = false;
        	porridgeCooking.active = false;
        }
	
        // Update is called once per frame
        void Update()
        {
        }
    }
}

