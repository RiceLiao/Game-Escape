using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

	public string SceneToLoad;
	public string LevelToUnlock;

	public CameraController theCameraController;
	public PlayerController thePlayController;
	public LevelManager theLevelManager;

	public float waitToMove;
	public float waitToLoad;

	public bool movePlayer;

	public SpriteRenderer theSpriteRender;
	public Sprite flagOpen;

	// Use this for initialization
	void Start () {
		theCameraController = FindObjectOfType<CameraController> ();
		thePlayController = FindObjectOfType<PlayerController> ();
		theLevelManager = FindObjectOfType<LevelManager> ();
		theSpriteRender = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (movePlayer) {
			thePlayController.myRigidbody.velocity = new Vector3 (thePlayController.moveSpeed, thePlayController.myRigidbody.velocity.y, 0f);
		}
	}

//	void OnCollisonEnter2D(Collision2D other){
//		if (other.gameObject.tag == "Player") {
//			Debug.Log ("Level End");
//			SceneManager.LoadScene (SceneToLoad);
//		}
//	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
//			SceneManager.LoadScene (SceneToLoad);
			StartCoroutine("LevelEndCo");
		}
	}

	public IEnumerator LevelEndCo(){
		thePlayController.canMove = false;
		theCameraController.followTarget = false;
		theLevelManager.invincible = true;

		thePlayController.myRigidbody.velocity = Vector3.zero;
		theSpriteRender.sprite = flagOpen;

		PlayerPrefs.SetInt ("CoinCount", theLevelManager.coinCount);
		PlayerPrefs.SetInt ("PlayerLives", theLevelManager.currentLives);

		PlayerPrefs.SetInt (LevelToUnlock, 1);

		yield return new WaitForSeconds (waitToMove);
		movePlayer = true;
		yield return new WaitForSeconds (waitToLoad);
		SceneManager.LoadScene (SceneToLoad);
	}
}
