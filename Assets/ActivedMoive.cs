using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivedMoive : MonoBehaviour {

	public PlayerController thePlayerController;

	// Use this for initialization
	void Start () {
		thePlayerController = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	// void Update () {
	// 	if(Input.GetButtonDown ("Jump") && (gameObject.transform.position.x <= -2) && (gameObject.transform.position.x >= -5)){
	// 		thePlayerController.canMove = false;
	// 	}
	// }
}
