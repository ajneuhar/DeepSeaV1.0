using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	
	[System.Serializable]  
	public class EnemyStats {
		public int health = 3;
	}
	
	public EnemyStats enemyStats = new EnemyStats();
	
	public void DamageEnemy (int damage) {
		
		enemyStats.health -= damage;
		
		if (enemyStats.health <= 0) {
			GameManager.KillEnemy(this);
			AddScore();
		} 


	}


	
	// Update is called once per frame
	void Update () {
		
		// When to damage the player. when enemy hits me - rigidbody. 
		if (Input.GetKeyDown(KeyCode.Space)) {
			//DamagePlayer(100);
		}
	}

	public void AddScore() {
		string tagOfEnemy = this.tag;

		switch(tagOfEnemy){
		case("enemy1"):
			GameManager.score += 5;
			break;
		case("enemy2"):
			GameManager.score += 17;
			break;
		case("enemy3"):
			GameManager.score += 39;
			break;
		case("enemy4"):
			GameManager.score += 52;
			break;
			
		}

	}

}
