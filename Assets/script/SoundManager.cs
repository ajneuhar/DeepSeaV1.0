using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private AudioSource sourceAudio;

	//Boat
	public AudioClip boatHitByEnemy;
	public AudioClip tookPowerUp;
	public AudioClip gotShield; 
	public AudioClip death;

	//Player
	public AudioClip smallTalkStart1;
	public AudioClip smallTalkStart2;
	public AudioClip smallTalkStart3;
	public AudioClip killEnemy1;
	public AudioClip killEnemy2;
	public AudioClip killEnemy3;
	public AudioClip killEnemy4;
	public AudioClip killEnemy5;
	public AudioClip killEnemy6;
	public AudioClip killEnemy7;
	public AudioClip killEnemy8;

	//Weapon
	public AudioClip gunShot;
	public AudioClip expArrow;

	//PowerUps
	public AudioClip gotLife;
	public AudioClip gotExpArrows;
	public AudioClip gotDepthArrows; 
	public AudioClip gotShield1;
	public AudioClip gotMachineGun;

	//creature sounds 
	public AudioClip enemyDeath; 

	//movie scenes music


	// Use this for initialization
	void Start () {
		sourceAudio = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.deathSound) {
			if (BoatMovement.counter == 3) {
				BoatMovement.counter = 0;
			}
			sourceAudio.PlayOneShot(death, 1f);
			GameManager.deathSound = false;
		}

		if (BoatMovement.counter == 3) {
			sourceAudio.PlayOneShot(boatHitByEnemy, 1f);
			BoatMovement.counter = 0;
		}

		if (PowerUps.tookPowerUp) {
			sourceAudio.PlayOneShot(tookPowerUp, 1f);
			PowerUps.tookPowerUp = false; 
		}

		if (PowerUps.haveShield) {
			sourceAudio.PlayOneShot(gotShield, 1f); 
			PowerUps.haveShield = false;
		}

		if (LevelManager.openSound) {

			switch(Random.Range(0, 3)) {
			case(0):
				sourceAudio.PlayOneShot(smallTalkStart1, 1f);
				break;
			case(1):
				sourceAudio.PlayOneShot(smallTalkStart2, 1f);
				break;
			default:
				sourceAudio.PlayOneShot(smallTalkStart3, 1f);
				break;
			}

			LevelManager.openSound = false; 
		}


		if (GameManager.killCount == 3) {

			switch (Random.Range(0, 8)) {
			case(0):
				sourceAudio.PlayOneShot(killEnemy1, 1f);
				break;
			case(1):
				sourceAudio.PlayOneShot(killEnemy2, 1f);
				break;
			case(2):
				sourceAudio.PlayOneShot(killEnemy3, 1f);
				break;
			case(3):
				sourceAudio.PlayOneShot(killEnemy4, 1f);
				break;
			case(4):
				sourceAudio.PlayOneShot(killEnemy5, 1f);
				break;
			case(5):
				sourceAudio.PlayOneShot(killEnemy6, 1f);
				break;
			case(6):
				sourceAudio.PlayOneShot(killEnemy7, 1f);
				break;
			default:
				sourceAudio.PlayOneShot(killEnemy8, 1f);
				break;
			}
			GameManager.killCount = 0;
		}

		if (SpearGun.gunShot) {
			sourceAudio.PlayOneShot(gunShot, 1f);
			SpearGun.gunShot = false;
		}

		if (Enemy.spearHitEnemy) {
			if (PowerUps.powerUp == 2){
				sourceAudio.PlayOneShot(expArrow, 1f);
				Enemy.spearHitEnemy = false;
			}
		}

		if (PowerUps.gotLife) {
			sourceAudio.PlayOneShot(gotLife, 1f);
			PowerUps.gotLife = false;
		}

		if (PowerUps.gotExpArrows) {
			sourceAudio.PlayOneShot(gotExpArrows, 1f);
			PowerUps.gotExpArrows = false;
		}

		if (PowerUps.gotDepthArrows) {
			sourceAudio.PlayOneShot(gotDepthArrows, 1f);
			PowerUps.gotDepthArrows = false;
		}

		if (PowerUps.gotShield) {
			sourceAudio.PlayOneShot(gotShield1, 1f);
			PowerUps.gotShield = false;
		}

		if (PowerUps.gotMachineGun) {
			sourceAudio.PlayOneShot(gotMachineGun, 1f);
			PowerUps.gotMachineGun = false;
		}

		if (GameManager.enemyDeath) {
			sourceAudio.PlayOneShot(enemyDeath, 1f);
			GameManager.enemyDeath = false;
		}


	}
}
