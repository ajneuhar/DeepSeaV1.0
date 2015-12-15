using System.Collections;
using UnityEngine;

public class BoatMovement : MonoBehaviour {

	public int boatSpeed = -2;
	public int boatSpeedMove = 10;
	public Player player;
	public int damageToPlayer = 20;
	public Transform front;
	public Transform back;
    public float yLimit;
    public float xLimit;

	private Rigidbody2D rb;
 

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir;

        yLimit = transform.position.y;
        xLimit = transform.position.x;

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate(Vector3.forward * boatSpeed);
			
		} else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			transform.Rotate(Vector3.forward * -boatSpeed);
		} 

		if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) {
                dir = (front.position - transform.position) * boatSpeedMove;
                rb.AddForce(dir);

		} else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			dir = (back.position - transform.position) * boatSpeedMove;
			rb.AddForce(dir);
		}

        // making sure that the player won't be able to get out of the main screen.
        if (yLimit > 65 || yLimit < -65 || xLimit > 100 || xLimit < -100)
        {
			StartCoroutine(OutOfBounds());	   
        }

	}

	IEnumerator OutOfBounds() {
		Renderer boatR = GetComponent<Renderer>();
		Renderer playerR = player.GetComponent<Renderer>();

		transform.position = new Vector3 (0f, 0f, 0f);
		rb.velocity = new Vector3(0f, 0f, 0f);
		player.DamagePlayer(damageToPlayer);
		player.SetUnTouchable(true);
		for (int i = 0; i < 6; i++) {
			boatR.enabled = !boatR.enabled;
			playerR.enabled = !playerR.enabled;
			yield return new WaitForSeconds(0.3f);
		}
			
		player.SetUnTouchable(false);
	}

	// Activate functhion when something touched the boat.
	void OnTriggerEnter2D (Collider2D other) {

		string tag = other.tag;
		if (tag == "enemy1" || tag == "enemy2" || tag == "enemy3" || tag == "enemy4" || tag == "enemy5") {
			Debug.Log("Player Got Hit!!!!!!!!!");
			player.DamagePlayer(damageToPlayer);
		}
	}
}
