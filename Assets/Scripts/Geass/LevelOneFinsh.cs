using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOneFinsh : MonoBehaviour {

	public Rigidbody2D thePlayerRgd;
	public MouthBoss boss;
	public float val;

	public Text lab_countDown;
	private float endTime;

	private bool isFinish = false;

	public FadeCtrl fadeCtrl;

	void Start () {
		endTime = Time.time + val;
		Invoke ("OnFinish", val);
	}
	
	void Update()
	{
		if(!isFinish)
		lab_countDown.text = ((int)(Mathf.Ceil(endTime - Time.time))).ToString();
	}

	public void OnFinish()
	{
		isFinish = true;
		if(!GameMgr.Instance.player.isDead){
			boss.ByeBye();
		}
		fadeCtrl.FadeOut(FadeComplete);
	}

	private void FadeComplete()
	{
		GameMgr.Instance.FinishLevel();
	}
}
