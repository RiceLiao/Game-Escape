using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour {

	public string LevelToLoad;

	public bool unlock;

	public Sprite doorBottomOpen;
	public Sprite doorTopOpen;
	public Sprite doorBottomClosed;
	public Sprite doorTopClosed;

	public SpriteRenderer doorBottom;
	public SpriteRenderer doorTop;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Level1", 1);

		if (PlayerPrefs.GetInt (LevelToLoad) == 1) {
			unlock = true;
		}

		if (unlock) {
			doorTop.sprite = doorTopOpen;
			doorBottom.sprite = doorBottomOpen;
		} else {
			doorTop.sprite = doorTopClosed;
			doorBottom.sprite = doorBottomClosed;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			if(Input.GetButtonDown("Jump") && unlock){
				SceneManager.LoadScene (LevelToLoad);
			}
		}
	}
}
