using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

	public float MoveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left*MoveSpeed*Time.deltaTime);
		if(transform.position.x <= -17.5f){
			transform.position = new Vector3(36f,transform.position.y,transform.position.z);
		}
	}
}
