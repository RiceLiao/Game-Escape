using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public float waitToRespawn;
	public PlayerController thePalyer;

	public GameObject deathSplosion;

	public int coinCount;
	public Text coinText;

	public AudioSource coinSound;

	public int MaxHealth;
	public int HealthCount;
	private bool respawning;

	public Image Heart1;
	public Image Heart2;
	public Image Heart3;

	public Sprite HeartFull;
	public Sprite HeartHalf;
	public Sprite HeartEmpty;

	public bool invincible;


	public Text livesText;
	public int startingLives;
	public int currentLives;

	public GameObject gameoverScreen;

	public AudioSource levelMusic;
	public AudioSource gameOverMusic;

	public bool respwanCoActive;

	private ResetOnRespawn[] ObjectsToReset;

	// Use this for initialization
	void Start () {
		thePalyer = FindObjectOfType<PlayerController> ();
		HealthCount = MaxHealth;
		ObjectsToReset = FindObjectsOfType<ResetOnRespawn> ();

		if (PlayerPrefs.HasKey ("CoinCount")) {
			coinCount = PlayerPrefs.GetInt ("CoinCount");
		}
		coinText.text = "Coins: " + coinCount;
		if (PlayerPrefs.HasKey ("PlayerLives")) {
			currentLives = PlayerPrefs.GetInt ("PlayerLives");

		}else{
			currentLives = startingLives;
		}
		livesText.text = "Lives x " + currentLives;
	}
	
	// Update is called once per frame
	void Update () {

		if (HealthCount <= 0 && !respawning) {
			Respawn ();
			respawning = true;
		}
		
	}

	public void Respawn(){
		currentLives -= 1;
		livesText.text = "Lives x " + currentLives;
		if (currentLives > 0) {
			StartCoroutine ("RespawnCo");
		} else {
			thePalyer.gameObject.SetActive (false);
			gameoverScreen.SetActive (true);
			levelMusic.Stop ();
			gameOverMusic.Play ();
		}
	}

	public IEnumerator RespawnCo(){

		respwanCoActive = true;

		thePalyer.gameObject.SetActive (false);

		Instantiate (deathSplosion, thePalyer.transform.position, thePalyer.transform.rotation);

		yield return new WaitForSeconds (waitToRespawn);
		respawning = false;

		respwanCoActive = false;
		coinCount = 0;
		coinText.text = "Coins: " + coinCount;

		HealthCount = MaxHealth;
		updateHeartMeter ();
		thePalyer.transform.position = thePalyer.respawnPosition;
		thePalyer.gameObject.SetActive (true);

		for (int i = 0; i < ObjectsToReset.Length; i++) {
			
			ObjectsToReset [i].gameObject.SetActive (true);
			ObjectsToReset [i].ResetObject ();
		}

	}

	public void AddCoin(int coinToAdd){
		coinCount += coinToAdd;
		coinText.text = "Coins: " + coinCount;
		coinSound.Play ();
	}

	public void AddLives(int livesToAdd){
		currentLives += livesToAdd;
		livesText.text = "Lives x " + currentLives;
		coinSound.Play ();
	}

	public void HeartPlayer(int damageToTake){
		if (!invincible) {
			HealthCount -= damageToTake;
			updateHeartMeter ();
			thePalyer.Knockback ();
		}
	}

	public void updateHeartMeter(){
		switch (HealthCount) {
		case 6:
			Heart1.sprite = HeartFull;
			Heart2.sprite = HeartFull;
			Heart3.sprite = HeartFull;
			break;
		case 5:
			Heart1.sprite = HeartFull;
			Heart2.sprite = HeartFull;
			Heart3.sprite = HeartHalf;
			break;
		case 4:
			Heart1.sprite = HeartFull;
			Heart2.sprite = HeartFull;
			Heart3.sprite = HeartEmpty;
			break;
		case 3:
			Heart1.sprite = HeartFull;
			Heart2.sprite = HeartHalf;
			Heart3.sprite = HeartEmpty;
			break;
		case 2:
			Heart1.sprite = HeartFull;
			Heart2.sprite = HeartEmpty;
			Heart3.sprite = HeartEmpty;
			break;
		case 1:
			Heart1.sprite = HeartHalf;
			Heart2.sprite = HeartEmpty;
			Heart3.sprite = HeartEmpty;
			break;
		case 0:
			Heart1.sprite = HeartEmpty;
			Heart2.sprite = HeartEmpty;
			Heart3.sprite = HeartEmpty;
			break;
		default:
			Heart1.sprite = HeartEmpty;
			Heart2.sprite = HeartEmpty;
			Heart3.sprite = HeartEmpty;
			break;
		}
	}

}
