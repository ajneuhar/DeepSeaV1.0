using UnityEngine;
using System.Collections;

public class WallBug : MonoBehaviour {
	/*
	IEnumerator OnCollisionStay2D (Collision2D other) {
		if (other == null) {
			//return false;
		}

		string tag = other.gameObject.tag;

		BoxCollider2D enemyB = other.gameObject.GetComponent<BoxCollider2D>();
		Animator anim = other.gameObject.GetComponent<Animator>();


		if ((tag == "enemy1" || tag == "enemy2" || tag == "enemy3") && anim.GetBool("death") == false) {
			Debug.Log("Enemy Hit Fucking Wall =====>>>>>  " + tag);
			enemyB.isTrigger = true;
			yield return new WaitForSeconds(0.4f);
			enemyB.isTrigger = false;
		}

	}
*/

}
