using UnityEngine;
using System.Collections;

public class CheckpointController: MonoBehaviour {

	public Sprite flagClosed;
	public Sprite flagOpen;

	private SpriteRenderer theSpriteRenderer;

	public bool checkpointAvtive;

	// Use this for initialization
	void Start () {
		theSpriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			theSpriteRenderer.sprite = flagOpen;
			checkpointAvtive = true;
		}
	}
}
