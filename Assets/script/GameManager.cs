using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public Text scoreText;
	public static int score;


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
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
	}
}
