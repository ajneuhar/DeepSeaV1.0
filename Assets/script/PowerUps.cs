using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	int powerUp;
	float powerUpTime;
	public Player player;
	public MoveBullet spear;
	private int playerRevive = 20;
	private Renderer powerUpR;


	// Use this for initialization
	void Start () {
		powerUpR = GetComponent<Renderer>();
		RandomPowerUp();

		
	}
	
	private void RandomPowerUp() {

		powerUp = Random.Range(1, 5);
		powerUpTime = Random.Range(20, 31);
	}

	IEnumerator ActivatePowerUp() {
		switch(powerUp) {
		case(1) :
			Debug.Log("got life");
			player.RevivePlayer(playerRevive);
			Destroy(this.gameObject);
			break;
		case(2) :

			spear.WeaponUpdate(2);
			Debug.Log("Update Weapon To ==============>" + spear.weaponHitLayer + "  " + spear.damageToEnemy);
			Debug.Log(Time.time);
			yield return new WaitForSeconds(powerUpTime);
			spear.WeaponUpdate(1);
			Debug.Log(Time.time);
			Destroy(this.gameObject);
			break;

		case(3) :
			spear.WeaponUpdate(3);
			Debug.Log("Update Weapon To ==============>" + spear.weaponHitLayer + "  " + spear.damageToEnemy);
			yield return new WaitForSeconds(powerUpTime);
			spear.WeaponUpdate(1);
			Destroy(this.gameObject);
			break;

		case(4) : 
			Debug.Log("Got Untouchable");
			player.SetUnTouchable(true);
			yield return new WaitForSeconds(10f);
			player.SetUnTouchable(false);
			Destroy(this.gameObject);
			break;
		}
	}

	//TODO: 
	void OnTriggerEnter2D (Collider2D other) {
		string tag = other.tag;

		if (tag == "Boat" && powerUpR.sortingOrder > 2) {
			StartCoroutine(ActivatePowerUp());
			transform.position = new Vector3(300f, 300f, 0f);
		}
	}


	
}
