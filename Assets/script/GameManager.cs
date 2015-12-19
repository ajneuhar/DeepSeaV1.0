using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public Text scoreText;
	public static int score;
	public GameObject enemy1;
	public static int numOfEnemys;
	public GameObject powerUp;
	int givePowerUp; 



	public static void KillPlayer (Player player) {
		Debug.Log ("Player has Been Killed");
	}

	public static void KillEnemy (Enemy enemy) {
		Destroy (enemy.gameObject);
	}

	// Use this for initialization
	void Start () {

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


	IEnumerator CreatePowerUp() {
		yield return new WaitForSeconds(2f);
		Instantiate(powerUp, new Vector3(13f, 50f, 0f), Quaternion.identity);
	}




}
