using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
	
	public Image bar; 
	

	// Update is called once per frame
	void Update()
	{
		switch (Player.playerStats.health) {
		case(100):
			bar.fillAmount = 1f;
			break; 
		case(90):
			bar.fillAmount = 0.9f;
			break;
		case(80):
			bar.fillAmount = 0.8f;
			break;
		case(70):
			bar.fillAmount = 0.7f;
			break;
		case(60):
			bar.fillAmount = 0.6f;
			break;
		case(50):
			bar.fillAmount = 0.5f;
			break;
		case(40):
			bar.fillAmount = 0.4f;
			break; 
		case(30):
			bar.fillAmount = 0.3f;
			break;
		case(20):
			bar.fillAmount = 0.2f;
			break;
		case(10):
			bar.fillAmount = 0.1f;
			break;
		default:
			bar.fillAmount = 0f;
			break;
		}
	}
}