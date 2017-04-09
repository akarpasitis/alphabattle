using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_Bullet : MonoBehaviour {
	public float timeBetweenBullets = 0.15f;
	public GameObject projectile;

	float nextBullet;

	// Use this for initialization
	void Awake () {
		nextBullet = 0f;

	}
	
	// Update is called once per frame
	void Update () {
		player_Controller myPlayer = transform.root.GetComponent<player_Controller> ();

		if (Input.GetAxisRaw ("Fire1") > 0 && nextBullet < Time.time) {
			nextBullet = Time.time + timeBetweenBullets;
			Vector3 rot;
			if (myPlayer.getFacing () == -1f){
				rot = new Vector3 (0, -90, 0);
			} else rot= new Vector3 (0, 90, 0);
			Instantiate (projectile, transform.position, Quaternion.Euler (rot));
		}
	}
}
