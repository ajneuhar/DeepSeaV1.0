using UnityEngine;
using System.Collections;

public class PowerUpMovement : MonoBehaviour {
	private Renderer powerR;

	float scaleToX;
	float scaleToY;


	void Start () {
		gameObject.GetComponent<Collider2D>().isTrigger = true;
		powerR = GetComponent<Renderer>();
		scaleToX = 3f;
		scaleToY = 3f;
		StartCoroutine(Uprising());
	}

	IEnumerator Uprising(){
		for (int i = 0; i < 3; i++) {
			yield return new WaitForSeconds(1.5f);
			iTween.ScaleTo(this.gameObject, new Vector3(scaleToX, scaleToY, 0f), 2f);
			powerR.sortingOrder++;
			scaleToX += 1.5f;
			scaleToY += 1.5f;
		}
		scaleToX = 3f;
		scaleToY = 3f;
		gameObject.GetComponent<Collider2D>().isTrigger = false;

	}
	

}
