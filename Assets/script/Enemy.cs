using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	
	[System.Serializable]  
	public class EnemyStats {
		public int health = 5;
	}
	
	public EnemyStats enemyStats = new EnemyStats();

	//For Sound
	public static bool spearHitEnemy;

	//For Animation
    Animator anim;


	void Start () {
		anim = GetComponent<Animator>();

	}
	
	public void DamageEnemy (int damage) {

		spearHitEnemy = true; 
		enemyStats.health -= damage;

		if (tag == "enemy3") {
			StartCoroutine(WaitForHitAnimation());
		}


		if (enemyStats.health <= 0) {
			anim.SetBool("death", true);

			GetComponent<Collider2D>().isTrigger = true;


			StartCoroutine(DeathAnimation());
			AddScore();
		} 


	}

	IEnumerator WaitForHitAnimation() {
		anim.SetBool("enemy3Hit", true);
		yield return new WaitForSeconds(2f);
		anim.SetBool("enemy3Hit", false);
	}


	IEnumerator DeathAnimation () {
		Debug.Log("im here");
	
		yield return new WaitForSeconds(1f);
		GameManager.numOfEnemys--;
		GameManager.KillEnemy(this);
	}

    public void EnemyTouchPlayer ()   {
        //TODO: kills the enemy when this function is called.
		anim.SetBool("death", true);

		// Yahav do we need to turn off trigger?
		// GetComponent<Collider2D>().isTrigger = false;
        Debug.Log("need to kill enemy");
		GameManager.numOfEnemys--;
        Destroy(this.gameObject, 1f);
    }


	public void AddScore() {
		string tagOfEnemy = this.tag;

		switch(tagOfEnemy) {
		case("enemy1"):
			GameManager.score += 16;
			break;
		case("enemy2"):
			GameManager.score += 23;
			break;
		case("enemy3"):
			GameManager.score += 42;
			break;
			
		}

	}

}
