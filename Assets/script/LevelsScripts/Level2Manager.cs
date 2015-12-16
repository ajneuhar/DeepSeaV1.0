using UnityEngine;
using System.Collections;

public class Level2Manager : MonoBehaviour {

	public GameObject enemy1;
	public GameObject powerUp;
	private bool levelIsOver;

	// Use this for initialization
	void Start () {
		levelIsOver = false;
		GameManager.numOfEnemys = 4;
		StartCoroutine(CreateEnemys());
		StartCoroutine(CreatePowerUp());
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.numOfEnemys == 0 && !levelIsOver) {
			//TODO: move to next level.
			Debug.Log("Next level Bitch!!!!!!!!!");
			levelIsOver = true;
		}
	}

	IEnumerator CreatePowerUp() {
		yield return new WaitForSeconds(2f);
		Instantiate(powerUp, VectorStartPowerUp(), Quaternion.identity);
	}

	IEnumerator CreateEnemys() {
		for (int i = 0; i < 4; i++) {
 			Instantiate(enemy1, VectorStartEnemy(), Quaternion.identity);
			yield return new WaitForSeconds(3f);
		}
	}

	public Vector3 VectorStartEnemy() {
		float x = Random.Range(-100,100);
		float y = Random.Range(-85,85);
		return new Vector3(x, y, 0f);
	}

	public Vector3 VectorStartPowerUp() {
		float x = Random.Range(-70,70);
		float y = Random.Range(-70,70);
		return new Vector3(x, y, 0f);
	}
}
