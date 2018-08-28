using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdpterWall : MonoBehaviour {

	public GameObject leftWall;
	public GameObject rightWall;
	public float gap = 9;
	public float rate;

	void Start () 
	{
		
	}
	
	void Update () {

		this.rate = GameMgr.Instance.mWidth / 17.77778f;

		leftWall.transform.position = new Vector3 (-gap * rate, 0, 0);
		rightWall.transform.position = new Vector3 (gap * rate, 0, 0);
	}
}
