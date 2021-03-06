using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garage_Door_Controller : MonoBehaviour {

	public bool resetable;
	public GameObject door;
	public GameObject gear;
	public bool startOpen;

	bool firstTrigger = false;
	bool open = true;
	Animator doorAnim;
	Animator gearAnim;
	AudioSource doorAudio;

	// Use this for initialization
	void Start () {
		doorAnim = door.GetComponent<Animator> ();
		gearAnim = gear.GetComponent<Animator> ();
		doorAudio = door.GetComponent<AudioSource> ();

		if(!startOpen){
			open = false;
			doorAnim.SetTrigger ("door_Trigger");
			doorAudio.Play ();
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag== "Player" && !firstTrigger){
			if (!resetable)
				firstTrigger = true;
			doorAnim.SetTrigger ("door_Trigger");
			open = !open;
			gearAnim.SetTrigger ("gear_Rotating");
			doorAudio.Play ();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
