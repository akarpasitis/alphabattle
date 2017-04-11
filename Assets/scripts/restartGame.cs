using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour {

	public float restartTime;
	bool resetNow = false;
	float resetTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(resetNow&&resetTime<=Time.time){
			
		}
		if (Input.GetKey ("escape"))
			Application.Quit ();

	}
	public void restartTheGame(){
		resetNow = true;
		resetTime = restartTime + Time.time;
		int scene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}
	public void quitGame(){
		Application.Quit ();
	}

}
