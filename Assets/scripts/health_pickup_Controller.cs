using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_pickup_Controller : MonoBehaviour {
	public float healthAmount;
	public AudioClip health_pickup_sound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			other.GetComponent<player_Health> ().addHealth (healthAmount);
			Destroy (transform.root.gameObject);
			AudioSource.PlayClipAtPoint (health_pickup_sound, transform.position, 5f);
		}
	}
}
