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

	public float stopRotate = 0.1f;

	public static int counter;

	private Rigidbody2D rb;
 

	// Use this for initialization
	void Start () {
		boatR = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		counter = 0;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 dir;

		if (rb.velocity.magnitude >= stopRotate) {

			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
				transform.Rotate(Vector3.forward * boatSpeed);

				
			} else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
				transform.Rotate(Vector3.forward * -boatSpeed);
			}
		}



		 

		if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) {
                dir = (front.position - transform.position) * boatSpeedMove;
                rb.AddForce(dir);



		} else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			dir = (back.position - transform.position) * (boatSpeedMove / 2);
			rb.AddForce(dir);
		}

      

	}



	/*
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
	*/


	// Activate functhion when something touched the boat.
	// Dosen't damage player if enemy is in layer 0.
	void OnCollisionStay2D (Collision2D other) {

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
				Debug.Log("Player Got Hit!!!!!!!!! Is UnTouchable?????  " + player.GetUnTouchable());
				if(!player.GetUnTouchable()) {
					StartCoroutine(BlinkBoat());
				}
			}
		}
	}


	void OnCollisionEnter2D (Collision2D other) {
		
		string tag = other.gameObject.tag;
		if (tag == "wall") { 
			
			// change the movement diraction of the boat if touching a wall.
			if (other.gameObject.name == "RightWall" || other.gameObject.name == "LeftWall") {
				rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
			} else {
				rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
			}
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
