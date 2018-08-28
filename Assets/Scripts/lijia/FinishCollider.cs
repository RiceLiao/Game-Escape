using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollider : MonoBehaviour 
{
	

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other != null && GameMgr.Instance.IsPlayer(other.gameObject))
		{
			GameMgr.Instance.FinishLevel ();
		}
	}

}
