using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;

	private LevelManager theLevelManager;
	private PlayerController thePlayer;

	public GameObject thePauseScreen;

	// Use this for initialization
	void Start () {
		theLevelManager = FindObjectOfType<LevelManager> ();
		thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Time.timeScale == 0f) {
				ResumeGame ();
			} else {
				PausedGame ();
			}

		}
	}

	public void PausedGame(){
		Time.timeScale = 0;
		thePauseScreen.SetActive (true);
		thePlayer.canMove = false;
		theLevelManager.levelMusic.Pause ();
	}

	public void ResumeGame(){

		Time.timeScale = 1;
		thePauseScreen.SetActive (false);
		thePlayer.canMove = true;
		theLevelManager.levelMusic.Play ();
	}

	public void LevelSelect(){

		Time.timeScale = 1f;

		PlayerPrefs.SetInt ("PlayerLives", theLevelManager.currentLives);
		PlayerPrefs.SetInt ("CoinCount", theLevelManager.coinCount);

		SceneManager.LoadScene (levelSelect);
	}

	public void QuitToMainMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (mainMenu);
	}

}