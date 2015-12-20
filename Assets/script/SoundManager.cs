using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private AudioSource sourceAudio;
	public AudioClip boatHitByEnemy;
	public AudioClip death;
	public AudioClip killEnemy1;
	public AudioClip killEnemy2;
	public AudioClip killEnemy3;
	public AudioClip killEnemy4;
	public AudioClip killEnemy5;
	public AudioClip killEnemy6;
	public AudioClip gunShot;



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

		if (GameManager.killCount == 3) {

			switch (Random.Range(0, 6)) {
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
			default:
				sourceAudio.PlayOneShot(killEnemy6, 1f);
				break;
			}
			GameManager.killCount = 0;
		}

		if (SpearGun.gunShot) {
			sourceAudio.PlayOneShot(gunShot, 1f);
			SpearGun.gunShot = false;
		}

	}
}
