using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthBoss : MonoBehaviour {

	public BossState state = BossState.Normal;

	public float downIdleTime = 0.5f;

	public Animator anim;

	public float moveSpeed = 1;

	public float halfWidth = 5.5f;

	public float leftX;
	public float rightX;
	public float timeOfStage1;
	public float waitToTurnStage2;
	public float attackRange = 5f;
	public GameObject thePlayer;
	private int bossStage;
	private bool canMove;
	private float startTime;

	void Start () 
	{
		startTime = Time.time;
		canMove = true;
		bossStage = 1;
		state = BossState.Appearing;
		float rate = GameMgr.Instance.mWidth / 17.77778f;
		leftX = -halfWidth * rate;
		rightX = halfWidth * rate;
	}

	private float _nextUpTime;
	void Update ()
	{
		if(Time.time > timeOfStage1 + startTime && Time.time < timeOfStage1 + startTime + waitToTurnStage2 && canMove){
			canMove = false;
			bossStage = 2;
			anim.Play("mouth_turnstage2");
			Invoke ("CanMove", waitToTurnStage2);
		}
		if(state != BossState.Appearing)
		{
			if (state == BossState.DownNormal && Time.time > _nextUpTime) 
			{
				state = BossState.Up;
				anim.Play ("mouth_up");
			}
			if(state != BossState.ByeBye && canMove){
				float currX = this.transform.position.x;
				if(currX < leftX && moveSpeed < 0)
				{
					moveSpeed *= -1;
				}
				else if(currX > rightX && moveSpeed > 0)
				{
					moveSpeed *= -1;
				}
				this.transform.position += new Vector3 (moveSpeed,0,0) * Time.deltaTime;
				if(((currX-thePlayer.transform.position.x <= attackRange+0.1 && currX-thePlayer.transform.position.x >= attackRange-0.1 && moveSpeed < 0) 
				|| (currX-thePlayer.transform.position.x >= -attackRange-0.1 && currX-thePlayer.transform.position.x <= -attackRange+0.1 && moveSpeed < 0))
				&& bossStage == 2 && state == BossState.Normal)
				{
					state = BossState.Down;
					anim.Play("mouth_down");
				}
			}
		}else
		{
			anim.Play ("mouth_appear");
		}
	}

	public void CanMove(){
		canMove = true;
	}
	public void Attack()
	{
		if(this.state == BossState.Normal && bossStage == 1)
		{
			state = BossState.Down;
			anim.Play ("mouth_down");
		}
	}

	public void DownOver()
	{
		state = BossState.DownNormal;
		_nextUpTime = Time.time + downIdleTime;
	}

	public void UpOver()
	{
		state = BossState.Normal;	
	}

	public void ByeBye()
	{
		state = BossState.ByeBye;
		 KillPlayer[] arr = this.gameObject.GetComponentsInChildren<KillPlayer>();
		foreach(var item in arr){
			item.enabled = false;
		}
		anim.Play("mouth_byebye");
	}
	public void AppearOver()
	{
		state = BossState.Normal;
	}
}
