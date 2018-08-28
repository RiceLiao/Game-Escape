using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class FadeCtrl : MonoBehaviour {

	private Image bg;
	public float outTime = 2f;
	
	void Start () {
		bg = this.GetComponent<Image>();
		bg.color = new Color(0,0,0,0);
	}
	
	public void FadeOut(TweenCallback callback)
	{
		Color col = new Color(0,0,0,1);
		bg.DOFade(1, outTime).OnComplete(callback);
	}

}
