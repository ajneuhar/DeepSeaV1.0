using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private int maxHealth = 100;
	bool unTouchable = false;

	[System.Serializable]  
	public class PlayerStats {
		public int health = 100;
	}

	public static PlayerStats playerStats;


	void Start() {
		playerStats = new PlayerStats();
	}

	public void DamagePlayer (int damage) {
		if (unTouchable){
			Debug.Log("Player UnTouchable mother fucker!!!!!!!");
			return;
		}

		playerStats.health -= damage;

		if (playerStats.health <= 0) {
			GameManager.KillPlayer(this);
		}
	}

	public void RevivePlayer (int revive) {

		if (playerStats.health <= maxHealth) {
			playerStats.health += revive;
		}
	}

	public void SetUnTouchable(bool a) {
		unTouchable = a;
	}
	
	// Update is called once per frame
	void Update () {

		// When to damage the player. when enemy hits me - rigidbody. 
		if (Input.GetKeyDown(KeyCode.Space)) {
			DamagePlayer(100);
		}
	}
}
