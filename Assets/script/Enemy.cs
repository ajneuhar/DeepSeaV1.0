using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	
	[System.Serializable]  
	public class EnemyStats {
		public int health = 5;
	}
	
	public EnemyStats enemyStats = new EnemyStats();
	
	public void DamageEnemy (int damage) {
		
		enemyStats.health -= damage;
		
		if (enemyStats.health <= 0) {
			GameManager.numOfEnemys--;
			GameManager.KillEnemy(this);
			AddScore();
		} 


	}

    public void EnemyTouchPlayer ()   {
        //TODO: kills the enemy when this function is called.
        Debug.Log("need to kill enemy");
		GameManager.numOfEnemys--;
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {

	}

	public void AddScore() {
		string tagOfEnemy = this.tag;

		switch(tagOfEnemy) {
		case("enemy1"):
			GameManager.score += 100;
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
