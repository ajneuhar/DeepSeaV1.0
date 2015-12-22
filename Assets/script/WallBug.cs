using UnityEngine;
using System.Collections;

public class WallBug : MonoBehaviour {

	IEnumerator OnCollisionStay2D (Collision2D other) {
		string tag = other.gameObject.tag;
		Debug.Log("Enemy Hit Fucking Wall =====>>>>>  " + tag);
		BoxCollider2D enemyB = other.gameObject.GetComponent<BoxCollider2D>();

		if ((tag == "enemy1" || tag == "enemy2" || tag == "enemy3") && enemyB.isTrigger == false) {
			Debug.Log("Enemy Hit Fucking Wall =====>>>>>  " + tag);
			enemyB.isTrigger = true;
			yield return new WaitForSeconds(0.4f);
			enemyB.isTrigger = false;
		}
	}


}
