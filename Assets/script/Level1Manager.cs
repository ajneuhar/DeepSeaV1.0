using UnityEngine;
using System.Collections;

public class Level1Manager : MonoBehaviour {

	public GameObject enemy1;


	// Use this for initialization
	void Start () {
		Instantiate(enemy1, new Vector3(0f, 50f, 0f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
