using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_Health : MonoBehaviour {
	public float fullHealth;
	float currentHealth;

	public GameObject playerDeathFX;

	//HUD
	public Slider playerHealthSlider;
	public Image damageScreenIndication;
	Color flashcolor = new Color(155f, 155f, 155f, 0.2f);
	float colorFlashSpeed = 5f;
	bool damaged = false;

	AudioSource playerAS;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		playerHealthSlider.maxValue = fullHealth;
		playerHealthSlider.value = currentHealth;

		playerAS = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		//hurt indication
		if (damaged) {
			damageScreenIndication.color = flashcolor;
		}else{
			damageScreenIndication.color = Color.Lerp (damageScreenIndication.color, Color.clear, colorFlashSpeed * Time.deltaTime);
		}
		damaged = false;

	}
	public void addDamage(float damage){
		currentHealth -= damage;
		playerHealthSlider.value = currentHealth;
		damaged = true;
		playerAS.Play ();
		if(currentHealth<=0){
			makeDead ();
		}
	}

	public void addHealth(float health){
		currentHealth += health;
		if (currentHealth > fullHealth) currentHealth = fullHealth;
		playerHealthSlider.value = currentHealth;
	}
	public void makeDead(){
		Instantiate (playerDeathFX, transform.position, Quaternion.Euler (new Vector3 (-90, 0, 0)));
		Destroy (gameObject);
	}
}

