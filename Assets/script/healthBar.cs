using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {

	public Image Bar;
	public float max_health = 100f;
	float cur_health = 0f;
	float tempHealth = 0f;

	// Use this for initialization
	void Start () {
		cur_health = max_health;
		//tempHealth = Player.playerStats.health;
		//InvokeRepeating("checksHealth", 0f, 0.1f);
	}

	void checksHealth() { 
		if (tempHealth < cur_health) {
			decreaseHealth();
		}
	}

	public void decreaseHealth(){
		cur_health -= 20f;
		float calc_health = cur_health / max_health;
		SetHealth (calc_health);
	}

	public void SetHealth(float myhealth){
		Bar.fillAmount = myhealth;
	}
}