using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHeadEyeTrigger : MonoBehaviour {

	private BigHead theBigHead;

	// Use this for initialization
	void Start () {
		theBigHead = FindObjectOfType<BigHead>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(GameMgr.Instance.IsPlayer(other.gameObject)){
			theBigHead.eyeApper = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if(GameMgr.Instance.IsPlayer(other.gameObject)){
			theBigHead.eyeApper = false;
		}
	}
}
