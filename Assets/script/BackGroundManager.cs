using UnityEngine;
using System.Collections;

public class BackGroundManager : MonoBehaviour {

	public Sprite men1;
	public Sprite men2;
	public Sprite men3;
	SpriteRenderer background;

	// Use this for initialization
	void Start () {
		background = GetComponent<SpriteRenderer>();
		StartCoroutine (Background ());
	}

	IEnumerator Background (){
		while (true) {
			background.sprite = men1;
			yield return new WaitForSeconds(0.05f);
			background.sprite = men2;
			yield return new WaitForSeconds(0.05f);
			background.sprite = men3;
			yield return new WaitForSeconds(0.05f);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
