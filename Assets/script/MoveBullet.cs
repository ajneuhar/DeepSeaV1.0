using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {

	public int weaponHitLayer = 2;
	public int damageToEnemy = 5;
	public int moveSpeed = 230; 







	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
		Destroy (gameObject, 1);
	}



	void OnTriggerEnter2D (Collider2D other) {
		string tag = other.tag;
		Debug.Log("Spear Hit something....... " + tag);

		
		if (tag == "enemy1" || tag == "enemy2" || tag == "enemy3" || tag == "enemy4") {
			Enemy enemy = other.GetComponent<Enemy>();
			SpriteRenderer sprite = enemy.GetComponent<SpriteRenderer>();
			Debug.Log("layer is :      " + sprite.sortingOrder);

			if (weaponHitLayer >= sprite.sortingOrder) {
				Destroy(this.gameObject);

				if (enemy != null) {
					Debug.Log("damage been done is =========> " + damageToEnemy);
					enemy.DamageEnemy(damageToEnemy);
				}
			}
		}	
	}


	// Update the wepon damage and what layer he can hit.
	// layer 3 is the shallowest.
	// layer 1 is the deepest.
	public void WeaponUpdate(int weaponType){
		switch(weaponType) {
		case(1) :
			weaponHitLayer = 2;
			damageToEnemy = 5;
			return;
			
		case(2) :
			weaponHitLayer = 2;
			damageToEnemy = 10;
			return;
			
		case(3) :
			weaponHitLayer = 1;
			damageToEnemy = 10;
			return;
		}
	}

}
