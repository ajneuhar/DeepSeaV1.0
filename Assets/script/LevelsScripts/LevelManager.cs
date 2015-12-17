using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject levelButton;
	public static bool levelOver; 
	private int levelNumOfEnemys;


	void Start () {
		levelNumOfEnemys = 1;
		NextLevel();
	}

	// Use this for initialization
	void NextLevel () {
		Debug.Log("Number of enemies" + levelNumOfEnemys);
		levelOver = false;
		GameManager.numOfEnemys = levelNumOfEnemys; 
		StartCoroutine(CreateEnemys());

	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.numOfEnemys == 0 && !levelOver) {
			//TODO: move to next level.
			Debug.Log("Next level Bitch!!!!!!!!!");
			levelOver = true;
			StartCoroutine (LevelChange());
		}
	}

	IEnumerator CreateEnemys() {
		for (int i = 0; i < levelNumOfEnemys; i++) {
			Instantiate(enemy1, VectorStartEnemy(), Quaternion.identity);
			yield return new WaitForSeconds(3f);
		}
	}
	
	public Vector3 VectorStartEnemy() {
		float x = Random.Range(-100,100);
		float y = Random.Range(-85,85);
		return new Vector3(x, y, 0f);
	}
	

	IEnumerator LevelChange () {
		yield return new WaitForSeconds (1f);
		levelNumOfEnemys++;
		levelButton.active = true;
	}


	public void onClickNextLevel () {
		levelButton.active = false;
		NextLevel();
	}
}
