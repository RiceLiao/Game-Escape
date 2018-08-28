using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	public float fadeTime;
	public Image theImage;

	// Use this for initialization
	void Start () {
		theImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		theImage.CrossFadeAlpha (0f, fadeTime, false);
	}
}
