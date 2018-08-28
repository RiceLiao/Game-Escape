using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoCG : MonoBehaviour {

	private bool isOver = false;
	public void Go(){
		isOver = true;
		
	}

	public void Update(){
		//if(isOver && Input.GetMouseButtonDown(0)){
		//	GameMgr.Instance.CurrLevel = 0;
		//    SceneManager.LoadScene ("CG_One");
		//}
	}
}
