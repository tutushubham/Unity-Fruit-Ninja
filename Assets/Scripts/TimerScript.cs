using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimerScript : MonoBehaviour {

	float timer = 120;
	public Text ttext;   
	public Text gameover;
	// Use this for initialization
	void Start () {
		InvokeRepeating("ReduceTime", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameover.enabled == true) {
//			if (Input.touchCount > 0 || Input.GetMouseButtonDown (0)) {
//				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//			}
			CancelInvoke("ReduceTime");
		}
	}

	void ReduceTime() {
		timer--;
		if (timer == 0) {
			FruitSpawner.instance.CancelInvoke ("SpawnFruit");
			CancelInvoke ("ReduceTime");
			gameover.GetComponent<Text>().enabled = true;
			Camera.main.GetComponent<AudioSource>().Pause();
		}
		int sec = (int)timer % 60; // calculate the seconds
		int min = (int)timer / 60; // calculate the minutes
		ttext.text = min + ":" + sec;
	}

//	void Reload()
//	{
//		Application.LoadLevel (Application.loadedLevel);
//	}
}
