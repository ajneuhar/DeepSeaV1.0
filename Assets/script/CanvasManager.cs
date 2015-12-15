using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
	
	public GameObject canvasOne;
	public GameObject canvasTwo;
	
	// Use this for initialization
	void Start () {
		canvasOne.active = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void onClickStartButton() {
		Application.LoadLevel("MainScene");
	}

	public void onClickExitButton() {
		Application.Quit();

	}

	public void onClickBackButton () {
		canvasOne.active = true;
		canvasTwo.active = false;
	}

	public void onClickTutorialButton()
	{
		Application.LoadLevel("Tutorial");
	}

	public void onClickCreditsButton () {
		canvasTwo.active = true;
		canvasOne.active = false;
	}
}