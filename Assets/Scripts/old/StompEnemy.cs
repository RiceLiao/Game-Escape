using UnityEngine;
using System.Collections;

public class StompEnemy : MonoBehaviour {

	public GameObject deathSplosion;

	public float bounceForce;
	private Rigidbody2D playerRigidbody2D;

	// Use this for initialization
	void Start () {
		playerRigidbody2D = transform.parent.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
//			Destroy (other.gameObject);
			other.gameObject.SetActive(false);

			Instantiate (deathSplosion, other.transform.position, other.transform.rotation);

			playerRigidbody2D.velocity = new Vector3 (playerRigidbody2D.velocity.x, bounceForce, 0f);
		}

		if (other.tag == "Boss") {
			playerRigidbody2D.velocity = new Vector3 (playerRigidbody2D.velocity.x, bounceForce, 0f);
			other.transform.parent.GetComponent<Boss> ().takeDamage = true;
		}
	}
}
