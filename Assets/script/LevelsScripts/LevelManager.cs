using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject levelButton;
	public static bool levelOver; 
	private int levelNumOfEnemys;
	public static string startPath;
	public static string secondPath;

    // our spear
    public MoveBullet spear;

    // Use this for initialization
    void Start () {
		levelNumOfEnemys = 1;
		NextLevel();
        // setting the spear to the regular spear (layers: 1-2 damage: 5)
        spear.WeaponUpdate(1); 
	}

	void NextLevel () {
		Debug.Log("Number of enemies" + levelNumOfEnemys);
		levelOver = false;
		GameManager.numOfEnemys = levelNumOfEnemys; 
		StartCoroutine(CreateEnemys());

	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.numOfEnemys == 0 && !levelOver) {
			levelOver = true;
            Debug.Log("Next level Bitch!!!!!!!!!");
            StartCoroutine (LevelChange());
		}
	}

	IEnumerator CreateEnemys() {
		for (int i = 0; i < levelNumOfEnemys; i++) {
			Instantiate(enemy1, VectorStartEnemy(), Quaternion.identity);
			yield return new WaitForSeconds(3f);
		}
	}

	// Picks the coordinates according to the path for the enemy. 
	public Vector3 VectorStartEnemy() {
		switch (Random.Range(0, 4)) {
		case(0):
			startPath = "enemyPath0";
			secondPath = "enemyPath1";
			return new Vector3(-1f, 93f, 0f);
		case(1):
			startPath = "enemyPath01";
			secondPath = "enemyPath2";
			return new Vector3(81f, 92f, 0f);
		case(2):
			startPath = "enemyPath02";
			secondPath = "enemyPath3";
			return new Vector3(-25f, -91f, 0f);
		default:
			startPath = "enemyPath03";
			switch(Random.Range (0, 2)) {
			case(0):
				secondPath = "enemyPath4";
				break;
			case(1):
				secondPath = "enemyPath5";
				break;
			}
			return new Vector3(-148f, -28f, 0f);
		}
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
