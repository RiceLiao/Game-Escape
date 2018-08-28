using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillHand : MonoBehaviour {

	public BossState state = BossState.Normal;
	//触发距离
	public float tirggerDis = 0.5f;
	//持续时间
	public float DownIdleTime = 0.5f;

	public float speed = 1;

	public Animator anim;

	public BoxCollider2D colliderCompoent;

	public LayerMask playerLayer;

	public KillHand linkHand;
	public float delayLinkHand = 0.2f;

	void Start () 
	{
		anim.speed = speed;
	}

	private float _nextUpTime;
	public float dis;

	void Update () 
	{
		this.dis = Mathf.Abs(GameMgr.Instance.player.transform.position.x-this.transform.position.x);
		if (dis < tirggerDis) 
		{
			TriggerDown ();
			if(linkHand != null)
			{
				linkHand.Invoke ("TriggerDown", delayLinkHand);
			}
		}
		if(this.state == BossState.DownNormal && Time.time > _nextUpTime)//判断是否上升
		{
			anim.Play ("hand_up");
		}
	}

	public void TriggerDown()
	{
		if(state == BossState.Normal)
		{
			anim.speed = speed;
			anim.Play ("hand_down");
			this.state = BossState.Down;
		}
	}

	public void TriggerAttack()
	{
		Collider2D playerColl = Physics2D.OverlapBox(this.transform.position, colliderCompoent.size, 0, playerLayer);
		if(playerColl != null && GameMgr.Instance.IsPlayer(playerColl.gameObject))
		{
			//打到玩家，直接死亡
			GameMgr.Instance.player.PlayerDead();
		}
		this.state = BossState.DownNormal;
		this._nextUpTime = Time.time + DownIdleTime;
	}

	public void UpOver()
	{
		this.state = BossState.Normal;
	}
}