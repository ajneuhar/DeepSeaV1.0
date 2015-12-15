using UnityEngine;
using System.Collections;

public class SpearGun : MonoBehaviour {



	public static int damageToPlayer = 1;

	public LayerMask whatToHit;
	public float fireRate = 0;

	public Transform bulletTrail;
	float timeToSpawn = 0;
	public float spawnRate = 10;

	public GameObject spear;

	float timeTofire = 0;
	Transform firepoint;



	// Use this for initialization
	void Awake () {
		firepoint = transform.FindChild("firepoint");
		if (firepoint == null) {
			Debug.LogError("No firepoint?! What?!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetKeyDown(KeyCode.Mouse0)) {
				fire ();
			}
		}
		else {
			if (Input.GetKey (KeyCode.Mouse0) && Time.time > timeTofire) {
				timeTofire = Time.time + 1/fireRate;
				fire ();
			}
		}
	}

	void fire () {
		Vector2 mousePostion = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
		                                    Camera.main.ScreenToWorldPoint (Input.mousePosition).y);

		Vector2 firePointPosition = new Vector2 (firepoint.position.x, firepoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePostion-firePointPosition, 100, whatToHit);
		if (Time.time >= timeToSpawn) {
			effect ();
			shootBullet();
			timeToSpawn = Time.time + 1/spawnRate;
		} 
		Debug.DrawLine (firePointPosition, (mousePostion-firePointPosition) * 100, Color.black);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);


		}
	}

	void effect () {
		//TODO: Instantiate (bulletTrail, firepoint.position, firepoint.rotation);
	}

	void shootBullet () {
		Instantiate (spear, firepoint.position, firepoint.rotation);
	}

}
