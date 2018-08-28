using UnityEngine;
using System.Collections;

public class SpiderController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D myRigidbody;
	public bool canMove;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			myRigidbody.velocity = new Vector3 (-moveSpeed, myRigidbody.position.y, 0f);
		}
	}

	void OnBecameVisible(){
		canMove = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "KillPlane") {
			//Destroy (gameObject);
			gameObject.SetActive(false);
		}
	}

	void OnEnable(){
		canMove = false;
	}

}
