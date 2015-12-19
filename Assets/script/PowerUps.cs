using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	int powerUp;
	float powerUpTime;
	public GameObject boat;
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
			player.SetUnTouchable(true);
			Debug.Log("is player untouchable =====> " + player.GetUnTouchable());
			yield return new WaitForSeconds(10f);
			player.SetUnTouchable(false);
			Debug.Log("is player untouchable =====> " + player.GetUnTouchable());
			Destroy(this.gameObject);
			break;
		}
	}


	//TODO: 
	void OnCollisionEnter2D (Collision2D other) {
		string tag = other.gameObject.tag;

		if (tag == "Boat" ) {
			transform.position = new Vector3(300f, 300f, 0f);
			StartCoroutine(ActivatePowerUp());

		}
	}



	
}
