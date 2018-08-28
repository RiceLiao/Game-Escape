using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMouthBossAttach : MonoBehaviour {
	public MouthBoss boss;
	public float delay = 0.5f;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(GameMgr.Instance.IsPlayer(other.gameObject))
		{
			boss.Invoke ("Attack", delay);
		}
	}
}
