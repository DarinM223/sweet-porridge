using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.3f;
	 
	public int drawDepth = -1000;
	private float alpha = 1.0f; 
	private int fadeDir = -1;
	 
	public void OnGUI() {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;	
		alpha = Mathf.Clamp01(alpha);	

		Color c = GUI.color;
		c.a = alpha;
		GUI.color = c;

		GUI.depth = drawDepth;
	 
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}
	 
	public void FadeIn() {
		fadeDir = -1;	
	}
	 
	public void FadeOut() {
		fadeDir = 1;	
	}
	 
	public void Start() {
		alpha=1;
		FadeIn();
	}
}
