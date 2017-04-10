using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_pickup_Controller : MonoBehaviour {
	public float healthAmount;

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
		}
	}
}
