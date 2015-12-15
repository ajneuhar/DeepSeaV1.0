using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
	
	public Image bar; 
	
	// Use this for initialization
	void Start() {
	}


	// Update is called once per frame
	void Update()
	{
		switch (Player.playerStats.health) {
		case(100):
			bar.fillAmount = 1f;
			break; 
		case(80):
			bar.fillAmount = 0.8f;
			break;
		case(60):
			bar.fillAmount = 0.6f;
			break;
		case(40):
			bar.fillAmount = 0.4f;
			break;
		case(20):
			bar.fillAmount = 0.2f;
			break;
		case(0):
			bar.fillAmount = 0.0f;
			break;
		}
	}
}