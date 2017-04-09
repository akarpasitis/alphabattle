using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			player_Health playerFalls = other.gameObject.GetComponent<player_Health> ();
			playerFalls.makeDead ();
		} else
			Destroy (gameObject);
	}
}
