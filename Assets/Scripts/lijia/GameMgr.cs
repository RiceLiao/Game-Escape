using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr {

	public static GameMgr Instance = new GameMgr();

	public float mWidth = 0;
	public float mHeight = 0;

	public int CurrLevel = 0;

	public string[] levelNames = new string[]{"Level1", "Level2", "Level4"};

	public PlayerController player;

	public void Init () 
	{
		this.mHeight = Camera.main.orthographicSize*2;
		float tH = Screen.height / mHeight;
		mWidth = Screen.width / tH;

		player = GameObject.FindObjectOfType<PlayerController> ();
	}

	public void ResetLevel()
	{
		SceneManager.LoadScene (this.levelNames[this.CurrLevel]);
	}

	public void FinishLevel()
	{
		CurrLevel++;

		if (this.CurrLevel < levelNames.Length) 
		{
			ResetLevel ();
		} else {
			//所有关卡结束了
			Debug.Log("所有关卡结束");
		}
	}

	public bool IsPlayer(GameObject go)
	{
		if (go != null && go == player.gameObject)
			return true;
		return false;
	}

}
