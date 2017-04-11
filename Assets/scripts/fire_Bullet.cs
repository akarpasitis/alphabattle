using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fire_Bullet : MonoBehaviour {
	public float timeBetweenBullets = 0.15f;
	public GameObject projectile;
	public Slider playerAmmoSlider;

	// bullet info

	public int  maxRounds;
	public int startingRounds;
	int remainingRounds;
	float nextBullet;

	//audio info

	AudioSource gunMuzzleAS;
	public AudioClip shootSound;
	public AudioClip reloadSound;

	//graphic info
	public Sprite weaponSprite;
	public Image weaponImage;


	// Use this for initialization
	void Awake () {
		nextBullet = 0f;
		remainingRounds = startingRounds;
		playerAmmoSlider.maxValue = maxRounds;
		playerAmmoSlider.value = remainingRounds;
		gunMuzzleAS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		player_Controller myPlayer = transform.root.GetComponent<player_Controller> ();

		if (Input.GetAxisRaw ("Fire1") > 0 && nextBullet < Time.time && remainingRounds>0) {
			nextBullet = Time.time + timeBetweenBullets;
			Vector3 rot;
			if (myPlayer.getFacing () == -1f){
				rot = new Vector3 (0, -90, 0);
			} else rot= new Vector3 (0, 90, 0);
			Instantiate (projectile, transform.position, Quaternion.Euler (rot));

			playASound (shootSound);

			remainingRounds -= 1;
			playerAmmoSlider.value = remainingRounds;
		}
	}

	public void recharge(){
		remainingRounds = maxRounds;
		playerAmmoSlider.value = remainingRounds;
		playASound (reloadSound);

	}
	void playASound(AudioClip playTheSound){
		gunMuzzleAS.clip = playTheSound;
		gunMuzzleAS.Play ();
	}

	public void initializeWeapon(){
		gunMuzzleAS.clip = reloadSound;
		gunMuzzleAS.Play ();
		nextBullet = 0;
		playerAmmoSlider.maxValue = maxRounds;
		playerAmmoSlider.value = remainingRounds;
		weaponImage.sprite = weaponSprite;

	}
}
