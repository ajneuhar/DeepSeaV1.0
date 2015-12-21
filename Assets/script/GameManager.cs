using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public Text scoreText;
	public static int score;
	public static int numOfEnemys;
	public GameObject powerUp;
	int givePowerUp;

	public static bool deathSound;
	public static int killCount;


	

	// Use this for initialization
	void Start () {
		killCount = 0; 

		// Initilizae score.
		score = 0;
		givePowerUp = 100;
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
		if (score >= givePowerUp && !LevelManager.levelOver) {
			StartCoroutine(CreatePowerUp());
			givePowerUp += 200;
		}
	}

	public static void KillPlayer (Player player) {
		deathSound = true;
		Debug.Log ("Player has Been Killed");
		
	}
	
	public static void KillEnemy (Enemy enemy) {
		killCount++;
		Destroy (enemy.gameObject);
	}


	IEnumerator CreatePowerUp() {
		yield return new WaitForSeconds(2f);
		Instantiate(powerUp, new Vector3(13f, 50f, 0f), Quaternion.identity);
	}




}
