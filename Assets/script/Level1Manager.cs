using UnityEngine;
using System.Collections;

public class Level1Manager : MonoBehaviour {

	public GameObject enemy1;
	public GameObject powerUp;
	public GameObject levelButton;
	private bool levelOver; 


	// Use this for initialization
	void Start () {
		levelOver = false;
		GameManager.numOfEnemys = 1;
		Instantiate(enemy1, new Vector3(0f, 50f, 0f), Quaternion.identity);
		StartCoroutine(CreatePowerUp());

	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.numOfEnemys == 0 && !levelOver) {
			levelOver = true; 
			//TODO: move to next level.
			Debug.Log("Next level Bitch!!!!!!!!!");
			StartCoroutine (LevelChange());
		}
	
	}

	IEnumerator LevelChange () {
		yield return new WaitForSeconds (1f);
		levelButton.active = true;
	}


	IEnumerator CreatePowerUp() {
		yield return new WaitForSeconds(2f);
		Instantiate(powerUp, new Vector3(13f, 50f, 0f), Quaternion.identity);
	}

	public void onClickNextLevel () {
		Application.LoadLevel("Level2");
	}
}
