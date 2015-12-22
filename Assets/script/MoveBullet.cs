using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveBullet : MonoBehaviour {

	public int weaponHitLayer;
	public int damageToEnemy;
	public int moveSpeed = 100; 


	public Sprite regSpear;
	public Sprite expSpear;
	public Sprite deepSpear;
	SpriteRenderer spearR;

	// For changing CurrentArrow image in the GUI.
	public Image CurrentArrow;
	public Sprite HeapDeepArrow;
	public Sprite HeapRegArrow;
	public Sprite HeapExpArrow;


	

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
		Destroy (gameObject, 2);
	}



	void OnTriggerEnter2D (Collider2D other) {
		string tag = other.tag;
		Debug.Log("Spear Hit something....... " + tag);

		
		if (tag == "enemy1" || tag == "enemy2" || tag == "enemy3" || tag == "enemy4") {
			Enemy enemy = other.GetComponent<Enemy>();
			SpriteRenderer sprite = enemy.GetComponent<SpriteRenderer>();
			Debug.Log("layer is :      " + sprite.sortingOrder);

			if (weaponHitLayer <= sprite.sortingOrder) {
				Destroy(this.gameObject);

				if (enemy != null) {
					Debug.Log("damage been done is =========> " + damageToEnemy);
					enemy.DamageEnemy(damageToEnemy);
				}
			}
		}	
	}


	// Update the wepon damage and what layer he can hit.
	// layer 2 is the shallowest.
	// layer 0 is the deepest.
	public void WeaponUpdate(int weaponType){
		spearR = GetComponent<SpriteRenderer>();
		CurrentArrow = GameObject.Find("CurrentArrow").GetComponent<Image>();

		switch(weaponType) {
		case(1) :
			weaponHitLayer = 1;
			damageToEnemy = 5;
			spearR.sprite = regSpear; 
			CurrentArrow.sprite = HeapRegArrow;
			return;
			
		case(2) :
			weaponHitLayer = 1;
			damageToEnemy = 10;
			spearR.sprite = expSpear; 
			CurrentArrow.sprite = HeapExpArrow;
			return;
			
		case(3) :
			weaponHitLayer = 0;
			damageToEnemy = 10;
			spearR.sprite = deepSpear; 
			CurrentArrow.sprite = HeapDeepArrow;
			return;
		}
	}

}
