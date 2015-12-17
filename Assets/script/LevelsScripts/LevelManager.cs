using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject levelButton;
	public static bool levelOver; 
	private int levelNumOfEnemys;

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
