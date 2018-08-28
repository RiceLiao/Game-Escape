using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHead : MonoBehaviour {

	// public float stayTime;
	public bool eyeApper;
	public bool headApper;

	private Animator anim;
	// Use this for initialization
	public GameObject theEye;
	private bool isUp;
	private bool turn1;
	void Start () {
		eyeApper = false;
		headApper = false;
		anim = GetComponent<Animator>();
		theEye.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		HeadAttack();
	}

	public void HeadAttack(){
		if(eyeApper && !headApper){
			theEye.SetActive(true);
			anim.Play("EyeApper");
		}
		if(headApper && !isUp){
			isUp = true;
			anim.Play("up");
		}
		if(!eyeApper && !headApper){
			theEye.SetActive(false);
		}
		if(!headApper){
			isUp = false;
		}
	}

	public void Up1(){
		anim.Play("up");
	}

	public void Up2(){
		anim.Play("up2");
	}
}
