using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoLevel1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Go(){
		GameMgr.Instance.ResetLevel();
	}
}
