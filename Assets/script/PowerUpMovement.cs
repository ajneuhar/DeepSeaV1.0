using UnityEngine;
using System.Collections;

public class PowerUpMovement : MonoBehaviour {
	private Renderer powerR;




	void Start () {
		gameObject.GetComponent<Collider2D>().isTrigger = true;
		powerR = GetComponent<Renderer>();
		StartCoroutine(Uprising());
	}

	IEnumerator Uprising(){
		for (int i = 0; i < 3; i++) {
			yield return new WaitForSeconds(1.5f);
			powerR.sortingOrder++;
		}
		gameObject.GetComponent<Collider2D>().isTrigger = false;

	}
	

}
