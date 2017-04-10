using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator_Controller : MonoBehaviour {
	public float resetTime;

	Animator elevAnim;
	AudioSource elevAS;

	float groundTime;
	bool elevUp = false;

	// Use this for initialization
	void Start () {
		elevAnim = GetComponent<Animator> ();
		elevAS = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		if(groundTime<=Time.time && elevUp){
			elevAnim.SetTrigger ("activate_Elevator");
			elevUp = false;
			elevAS.Play ();
		}
	}
	void OnTriggerEnter (Collider other){
		if (other.tag =="Player"){
			elevAnim.SetTrigger("activate_Elevator");
			groundTime = Time.time + resetTime;
			elevUp = true;
			elevAS.Play();
		}
	}
}
