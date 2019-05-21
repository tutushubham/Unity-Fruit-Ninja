using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour {

//	private GameObject gameObject;
//	[SerializeField]


	// Use this for initialization
	void Start () {
//		gameObject = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -30)
		{
			Destroy(gameObject);
		}
	}
		
//	void OnCollisionEnter(Collision other)
//	{
//		Debug.Log (other.gameObject.tag);
//		if(other.gameObject.tag == "Line")
//		{
////			Camera.main.GetComponent<AudioSource>().Play();
//			Destroy(gameObject);
//
//
//		}
//	}

//	void OnTriggerEnter(Collider other) {
//		if(other.gameObject.tag == "Line")
//		{
//			//			Camera.main.GetComponent<AudioSource>().Play();
//			Destroy(gameObject);
//
//
//		}
//	}
}
