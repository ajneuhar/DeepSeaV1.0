using System.Collections;
using UnityEngine;

public class BoatMovement : MonoBehaviour {

	public int boatSpeed = -2;
	public int boatSpeedMove = 10;
	public Player player;
	public int damageToPlayer;
	public Transform front;
	public Transform back;

	public Sprite redBoat;
	public Sprite regBoat;
	SpriteRenderer boatR;

	public static int counter;

	private Rigidbody2D rb;
 

	// Use this for initialization
	void Start () {
		boatR = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		counter = 0;

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir;


		 

		if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) {
                dir = (front.position - transform.position) * boatSpeedMove;
                rb.AddForce(dir);

			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
				transform.Rotate(Vector3.forward * boatSpeed);
				
			} else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
				transform.Rotate(Vector3.forward * -boatSpeed);
			}

		} /*else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			dir = (back.position - transform.position) * boatSpeedMove;
			rb.AddForce(dir);
		}*/

      

	}




	IEnumerator OutOfBounds() {

		transform.position = new Vector3 (0f, 0f, 0f);
		rb.velocity = new Vector3(0f, 0f, 0f);
		player.DamagePlayer(damageToPlayer);
		player.SetUnTouchable(true);

		for (int i = 0; i < 3; i++) {
			boatR.sprite = redBoat;
			yield return new WaitForSeconds(0.3f);
			boatR.sprite = regBoat;
			yield return new WaitForSeconds(0.3f);
		}

			
		player.SetUnTouchable(false);
	}



	// Activate functhion when something touched the boat.
	// Dosen't damage player if enemy is in layer 0.
	void OnCollisionEnter2D (Collision2D other) {

		string tag = other.gameObject.tag;

		switch(tag) {
		case("enemy1"):
			damageToPlayer = 10;
			break;
		case("enemy2"):
			damageToPlayer = 20;
			break;
		case("enemy3"):
			damageToPlayer = 30;
			break;
		}

		if (tag == "enemy1" || tag == "enemy2" || tag == "enemy3" || tag == "enemy4" || tag == "enemy5") {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
			Renderer enemyR = other.gameObject.GetComponent<Renderer>();
			if(enemyR.sortingOrder >= 1) {
				counter++;
				player.DamagePlayer(damageToPlayer);
                enemy.EnemyTouchPlayer();
				Debug.Log("Player Got Hit!!!!!!!!!");
				if(!player.GetUnTouchable()) {
					StartCoroutine(BlinkBoat());
				}
			}
		} else if (tag == "wall") {
			rb.velocity = -rb.velocity;
		}
	}

	IEnumerator BlinkBoat() {
		for (int i = 0; i < 3; i++) {
			boatR.sprite = redBoat;
			yield return new WaitForSeconds(0.3f);
			boatR.sprite = regBoat;
			yield return new WaitForSeconds(0.3f);
		}
	}
	
}
