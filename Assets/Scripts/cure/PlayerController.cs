using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public Rigidbody2D myRigidbody;
	public float jumpSpeed;
	public bool canMove;

	public BoxCollider2D groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isGrounded;

	private Animator myAnim;

	public Vector3 respawnPosition;
	public LevelManager theLevelManager;

	public GameObject StompBox;

	public float knockbackForce;
	public float knockbackLength;
	private float knockbackCounter;

	public float invincibilityLength;
	private float invincibilityCounter;

	public Animation theDeadAnimation;

	public bool isDead;

	public AudioSource[] deathsound = new AudioSource[3];
	public float delayDeadTime = 2;

    public bool isForceJump = false;
	public GameOverManager gameOverManager;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		canMove = true;
		respawnPosition = transform.position;
		theLevelManager = FindObjectOfType<LevelManager> ();
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {

		isGrounded = Physics2D.OverlapBox (groundCheck.transform.position, groundCheck.size, 0, whatIsGround);
		if (knockbackCounter <= 0 && canMove && !isDead) {

			if (Input.GetAxisRaw ("Horizontal") > 0f) {
				myRigidbody.velocity = new Vector3 (moveSpeed, myRigidbody.velocity.y, 0f);
				// transform.localScale = new Vector3 (1f, 1f, 1f);
			} else if (Input.GetAxisRaw ("Horizontal") < 0f) {
				myRigidbody.velocity = new Vector3 (-moveSpeed, myRigidbody.velocity.y, 0f);
				// transform.localScale = new Vector3 (-1f, 1f, 1f);
			} else {
				myRigidbody.velocity = new Vector3 (0f, myRigidbody.velocity.y, 0f);
			}

			if (Input.GetButtonDown ("Jump") && (isGrounded || isForceJump)) {
				myRigidbody.velocity = new Vector3 (myRigidbody.velocity.x, jumpSpeed, 0f);
				//  jumpSound.Play ();
			}

		} 
			
		if (invincibilityCounter <= 0) {
			theLevelManager.invincible = false;
		}

		if (knockbackCounter > 0) {
			knockbackCounter -= Time.deltaTime;
			if (transform.localScale.x > 0) {
				myRigidbody.velocity = new Vector3 (-knockbackForce, knockbackForce, 0f);
			} else {
				myRigidbody.velocity = new Vector3 (knockbackForce, knockbackForce, 0f);
			}
		}


		myAnim.SetFloat ("Speed", Math.Abs(myRigidbody.velocity.x));
		myAnim.SetBool ("Grounded", isGrounded);
	}

	public void Knockback(){
		knockbackCounter = knockbackLength;
		invincibilityCounter = invincibilityLength;
		theLevelManager.invincible = true;
	}

	public void PlayerDead(){
		int randomSound = UnityEngine.Random.Range(0,3);
		deathsound[randomSound].Play();
		isDead = true;
		myAnim.SetBool ("isDead", isDead);
		myRigidbody.velocity = new Vector3 (0f, 0f, 0f);
		Debug.Log("Dead");
		gameOverManager.GameOver(DelayDead);
		// this.Invoke("DelayDead", delayDeadTime);
	}

	private void DelayDead(){
		GameMgr.Instance.ResetLevel();
	}

	// void OnTriggerEnter2D(Collider2D other){

	// 	if (other.tag == "KillPlane") {
	// 		//gameObject.SetActive (false);
	// 		//transform.position = respawnPosition;
	// 		//theLevelManager.Respawn();

	// 		theLevelManager.HealthCount = 0;
	// 	}

	// 	if (other.tag == "Checkpoint") {
	// 		respawnPosition = other.transform.position;
	// 	}

	// 	if (other.tag == "BossAttackBox") {
	// 		theMouthController.zhuangTaiInt=1;
	// 		Invoke("ZT",0.5f);
	// 	}
	// }

	// void OnCollisionEnter2D(Collision2D other){

	// 	if (other.gameObject.tag == "MovingPlatform") {
	// 		transform.parent = other.transform;
	// 	}

	// }

	// void OnCollisionExit2D(Collision2D other){

	// 	if (other.gameObject.tag == "MovingPlatform") {
	// 		transform.parent = null;
	// 	}

	// }
}