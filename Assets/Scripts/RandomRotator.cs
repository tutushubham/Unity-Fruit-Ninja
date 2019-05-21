using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
	public float tumble;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble;
//		GetComponent<Rigidbody> ().rotation = Quaternion.Euler(Random.Range(0f,360f),Random.Range(0f,360f),0f);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
