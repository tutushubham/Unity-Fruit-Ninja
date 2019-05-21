using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	public static FruitSpawner instance;
	[SerializeField]
	private GameObject[] fruits;


	void Awake() {
		if (instance == null)
			instance = this;
	}

	// Use this for initialization
	void Start()
	{
		InvokeRepeating("SpawnFruit", 2f, 2.8f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnFruit()
	{
		for (byte i = 0; i < 4; i++)
		{
			int pos = Random.Range (0, 4);
//			int pos = 3;
			var randomRotation = Quaternion.Euler( Random.Range(0, 360) , Random.Range(0, 360) , Random.Range(0, 360));
			GameObject fruit = Instantiate(fruits[pos], new Vector3(Random.Range(-4.5f, 4.5f), -5.0f, 1.0f), randomRotation) as GameObject;
			Vector3 throwForce = new Vector3(0, Random.Range(10,14), 0);
			fruit.GetComponent<Rigidbody>().AddForce (throwForce, ForceMode.VelocityChange);
			Debug.Log ("Fruit" + fruit.transform.position.z.ToString ());
		}
	}
}
