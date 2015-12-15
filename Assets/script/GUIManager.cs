using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	
	public Vector2 size = new Vector2(60, 20);
	public float posX = 40;
	public float posY = 60;
	public static float barDisplay = 1f;
	public static bool healthBarOn = false;   
	
	// Use this for initialization
	void Start() {
	}
	
	public void OnGUI() {
			// draw the background:
			GUI.BeginGroup(new Rect(posX, posY , size.x, size.y));
			GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);
			
			// draw the filled-in part:
			GUI.BeginGroup(new Rect(0, (size.y - (size.y * barDisplay)), size.x, size.y * barDisplay));
			GUI.Box(new Rect(0, -size.y + (size.y * barDisplay), size.x, size.y), progressBarFull);
			GUI.EndGroup();
			GUI.EndGroup();
	}
	
	// Update is called once per frame
	void Update()
	{
		switch (Player.playerStats.health) {
		case(100):
			barDisplay = 1f;
			break; 
		case(80):
			barDisplay = 0.8f;
			break;
		case(60):
			barDisplay = 0.6f;
			break;
		case(40):
			barDisplay = 0.4f;
			break;
		case(20):
			barDisplay = 0.2f;
			break;
		case(0):
			barDisplay = 0.0f;
			break;
		}
	}
}