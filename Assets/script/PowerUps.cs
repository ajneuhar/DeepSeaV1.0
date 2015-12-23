using UnityEngine;
using System.Collections;


public class PowerUps : MonoBehaviour {

	public static int powerUp;
	float powerUpTime;

	// For changing the player untouchable.
	private Player player;
	// For update the spear.
	public MoveBullet spear;
	private int playerRevive = 20;


	// For changing the boat sprite.
	private SpriteRenderer boatR;
	public Sprite regBoat;
	public Sprite untouchableBoat;

	// For changing Fire Rate.
	private SpearGun spearGun;

	//For Animation
	Animator anim;
	
	//For sound
	public static bool tookPowerUp;
	public static bool haveShield;
	public static bool gotLife; 
	public static bool gotExpArrows; 
	public static bool gotDepthArrows; 
	public static bool gotShield; 
	public static bool gotMachineGun;




	// Use this for initialization
	void Start () {
		boatR = GameObject.Find("Boat").GetComponent<SpriteRenderer>();
		player = GameObject.Find("Player").GetComponent<Player>();
		spearGun = GameObject.Find("spearGun").GetComponent<SpearGun>();
		anim = GetComponent<Animator>();

		RandomPowerUp();
	}
	

	private void RandomPowerUp() {

		powerUp = Random.Range(1, 6);
		powerUpTime = Random.Range(20, 31);
	}

	IEnumerator ActivatePowerUp() {
		switch(powerUp) {
	
		case(1) :
			gotLife = true;
			Debug.Log("got life");
			player.RevivePlayer(playerRevive);
			Destroy(this.gameObject);
			break;
		
		case(2) :
			gotExpArrows = true; 
			spear.WeaponUpdate(2);
			Debug.Log("Update Weapon To ==============>" + spear.weaponHitLayer + "  " + spear.damageToEnemy);
			Debug.Log(Time.time);
			yield return new WaitForSeconds(powerUpTime);
			spear.WeaponUpdate(1);
			Debug.Log(Time.time);
			Destroy(this.gameObject);
			break;

		case(3) :
			gotDepthArrows = true;
			spear.WeaponUpdate(3);
			Debug.Log("Update Weapon To ==============>" + spear.weaponHitLayer + "  " + spear.damageToEnemy);
			yield return new WaitForSeconds(powerUpTime);
			spear.WeaponUpdate(1);
			Destroy(this.gameObject);
			break;

		case(4) : 
			gotShield = true; 
			boatR.sprite = untouchableBoat;
			haveShield = true; 
			player.SetUnTouchable(true);
			Debug.Log("is player untouchable =====> " + player.GetUnTouchable());
	
			yield return new WaitForSeconds(10f);

			boatR.sprite = regBoat;
			player.SetUnTouchable(false);
			Debug.Log("is player untouchable =====> " + player.GetUnTouchable());
			Destroy(this.gameObject);
			break;

		case(5) :
			gotMachineGun = true;
			spearGun.fireRate = 4;

			yield return new WaitForSeconds(powerUpTime);

			spearGun.fireRate = 2;
			break;
		}


	}


	//TODO: 
	void OnCollisionEnter2D (Collision2D other) {
		string tag = other.gameObject.tag;

		if (tag == "Boat" ) {

			tookPowerUp = true; 

			anim.SetBool("tookPowerUp", true);

			GetComponent<Collider2D>().isTrigger = true;

			/*
			Object box = Instantiate(boxExplode, transform.position, Quaternion.identity);
			transform.position = new Vector3 (1000f, 0f, 0f);
			Destroy(box, 2f);
			*/

			StartCoroutine(ActivatePowerUp());

		}
	}





	
}
