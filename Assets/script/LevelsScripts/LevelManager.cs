using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject levelButton;
	public static bool levelOver; 
	private int level;
	public static string startPath;
	public static string secondPath;
	private int numEnemy1;
	private int numEnemy2;
	private int numEnemy3;

    // our spear
    public MoveBullet spear;

    // Use this for initialization
    void Start () {
		level = 1;
		CalcNextLevelEnemys();
		NextLevel();
		// setting the spear to the regular spear (layers: 1-2 damage: 5)
		//spear.WeaponUpdate(1);
	}


	void NextLevel () {
		levelOver = false; 
		CreateEnemys();

	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.numOfEnemys == 0 && !levelOver) {
			levelOver = true;
            Debug.Log("Next level Bitch!!!!!!!!!");
            StartCoroutine (LevelChange());
		}
	}


	void CreateEnemys() {
		StartCoroutine(CreateEnemy1());
		StartCoroutine(CreateEnemy2());
		StartCoroutine(CreateEnemy3());
	}

	IEnumerator CreateEnemy1() {
		for (int i = 0; i < numEnemy1; i++) {
			Instantiate(enemy1, VectorStartEnemy(), Quaternion.identity);
			yield return new WaitForSeconds(3f);
		}
	}

	IEnumerator CreateEnemy2() {
		for (int i = 0; i < numEnemy2; i++) {
			Instantiate(enemy2, VectorStartEnemy(), Quaternion.identity);
			yield return new WaitForSeconds(3f);
		}
	}

	IEnumerator CreateEnemy3() {
		for (int i = 0; i < numEnemy3; i++) {
			Instantiate(enemy3, VectorStartEnemy(), Quaternion.identity);
			yield return new WaitForSeconds(3f);
		}
	}


	// Picks the coordinates according to the path for the enemy. 
	public Vector3 VectorStartEnemy() {

		float posX = Random.Range(-150, 151);
		float posY = Random.Range(-100, 101);
		Vector3 startSpot = new Vector3(posX, posY, 0f);

		switch (Random.Range(0, 10)) {
		case(0):
			startPath = "enemyPath0";
			return startSpot;
		case(1):
			startPath = "enemyPath1";
			return startSpot;
		case(2):
			startPath = "enemyPath2";
			return startSpot;
		case(3):
			startPath = "enemyPath3";
			return startSpot;
		case(4):
			startPath = "enemyPath4";
			return startSpot;
		case(5):
			startPath = "enemyPath5";
			return startSpot;
		case(6):
			startPath = "enemyPath6";
			return startSpot;
		case(7):
			startPath = "enemyPath7";
			return startSpot;
		default:
			startPath = "enemyPath8";
			return startSpot;
		}
	}
	

	IEnumerator LevelChange () {
		yield return new WaitForSeconds (1f);
		level++;
		CalcNextLevelEnemys();
		levelButton.active = true;
	}


	public void onClickNextLevel () {
		levelButton.active = false;
		NextLevel();
	}

	// Calculate the number of each enemy.
	void CalcNextLevelEnemys() {
		int numTotal = 0;

		if (level < 8) {
			switch(level) {
			
			case(1) :
				numEnemy1 = 1;
				numEnemy2 = 0;
				numEnemy3 = 0;
				numTotal = numEnemy1 + numEnemy2 + numEnemy3;
				break;
			
			case(2) :
				numEnemy1 = 1;
				numEnemy2 = 1;
				numEnemy3 = 0;
				numTotal = numEnemy1 + numEnemy2 + numEnemy3;
				break;

			case(3) :
				numEnemy1 = 1;
				numEnemy2 = 2;
				numEnemy3 = 0;
				numTotal = numEnemy1 + numEnemy2 + numEnemy3;
				break;

			case(4) :
				numEnemy1 = 1;
				numEnemy2 = 1;
				numEnemy3 = 1;
				numTotal = numEnemy1 + numEnemy2 + numEnemy3;
				break;

			case(5) :
				numEnemy1 = 3;
				numEnemy2 = 0;
				numEnemy3 = 1;
				numTotal = numEnemy1 + numEnemy2 + numEnemy3;
				break;

			case(6):
				numEnemy1 = 2;
				numEnemy2 = 2;
				numEnemy3 = 1;
				numTotal = numEnemy1 + numEnemy2 + numEnemy3;
				break;
			
			case(7):
				numEnemy1 = 2;
				numEnemy2 = 3;
				numEnemy3 = 2;
				numTotal = numEnemy1 + numEnemy2 + numEnemy3;
				break;
			} 

		} else {
			numTotal = (int) (7 * (1 + (level - 7) * (level - 7) * 0.04));
			Debug.Log("numTotal ======>" + numTotal);
			// determens the number of enemy 1 (between 30-50 percent of the total number of enemies).
			numEnemy1 = (int) ((Random.Range(30, 51) / 100f) * numTotal);
			Debug.Log("numEnemy1 ======>" + numEnemy1);
			// determens the number of enemy 2 (between 30-45 percent of the total number of enemies).
			numEnemy2 = (int) ((Random.Range(30, 46) / 100f) * numTotal);
			Debug.Log("numEnemy2 ======>" + numEnemy2);
			numEnemy3 = numTotal - numEnemy2 - numEnemy1;
		}
		GameManager.numOfEnemys = numTotal;
	}
}

