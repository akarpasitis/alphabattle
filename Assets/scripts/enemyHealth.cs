using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

	public float enemyMaxHealth;
	public float damageModifier;
	public GameObject damageParticles;
	public bool drops;
	public GameObject drop;
	public AudioClip deathSound;
	public bool flammable;
	public float burnDamage;
	public GameObject burnFX;
	public float burnTime;

	bool onFire;
	float nextBurn;
	float burnInterval = 1f;
	float endBurn;

	float currentHealth;

	public Slider enemyHealthIndicator;

	AudioSource enemyAS;


	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;
		enemyHealthIndicator.maxValue = enemyMaxHealth;
		enemyHealthIndicator.value = currentHealth;
		enemyAS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(onFire && Time.time>nextBurn){
			addDamage (burnDamage);
			nextBurn += burnInterval;

		}
		if(onFire && Time.time>endBurn){
			onFire = false;
			burnFX.SetActive (false);
		}
	}
	public void addDamage(float damage){
		enemyHealthIndicator.gameObject.SetActive (true);
		damage = damage * damageModifier;
		if (damage <= 0f) return;
		currentHealth -= damage;
		enemyHealthIndicator.value = currentHealth;
		enemyAS.Play ();
		if (currentHealth <= 0)makeDead ();
	}
	public void addFire(){
		if (!flammable) return;
		onFire = true;
		burnFX.SetActive (true);
		endBurn = Time.time + burnTime;
		nextBurn = Time.time + burnInterval;
	}
	public void damageFX(Vector3 point, Vector3 rotation){
		Instantiate (damageParticles, point, Quaternion.Euler (rotation));
	}

	void makeDead(){
		AudioSource.PlayClipAtPoint (deathSound, transform.position, 0.5f);
		Destroy (gameObject.transform.root.gameObject);
		if (drops) Instantiate (drop, transform.position, transform.rotation);
	}

}
