﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy_PickUp_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			other.GetComponentInChildren<fire_Bullet> ().recharge ();
			Destroy (transform.root.gameObject);
		}
	}
}