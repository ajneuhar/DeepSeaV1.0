using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public Text scoreText;
	public static int score;
	public GameObject enemy1;
	public static int numOfEnemys;


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
		//StartCoroutine(Creatures ());
	}

	/*
	IEnumerator Creatures() {
		while (true) {
			Instantiate(enemy1, new Vector3(0f , 50f, 0f), Quaternion.identity);
			yield return new WaitForSeconds(5f);
		}
	}*/

	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
	}
}
