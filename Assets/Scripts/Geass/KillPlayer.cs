using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	
	public GameOverManager theGameOverManager;

	private PlayerController thePlayerController;
	// Use this for initialization
	void Start () {
		thePlayerController = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(this.enabled && other.gameObject.tag == "Player")
		{
			// theGameOverManager.GameOver(thePlayerController.PlayerDead);
			thePlayerController.PlayerDead();
		}
	}
}