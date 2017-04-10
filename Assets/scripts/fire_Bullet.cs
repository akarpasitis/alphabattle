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

	// Use this for initialization
	void Awake () {
		nextBullet = 0f;
		remainingRounds = startingRounds;
		playerAmmoSlider.maxValue = maxRounds;
		playerAmmoSlider.value = remainingRounds;
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

			remainingRounds -= 1;
			playerAmmoSlider.value = remainingRounds;
		}
	}
}
