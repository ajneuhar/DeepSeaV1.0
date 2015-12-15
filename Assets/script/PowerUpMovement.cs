using UnityEngine;
using System.Collections;

public class PowerUpMovement : MonoBehaviour {
	private Renderer powerR;




	void Start () {
		powerR = GetComponent<Renderer>();
		StartCoroutine(Uprising());
	}

	IEnumerator Uprising(){
		for (int i = 0; i < 4; i++) {
			yield return new WaitForSeconds(1.5f);
			powerR.sortingOrder++;
		}
	}
	

}
