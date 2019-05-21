using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Blade : MonoBehaviour {

	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = 0.001f;

	bool isCutting = false;

	Vector3 previousPosition;

	GameObject currentBladeTrail;

	Rigidbody rb;
	Camera cam;
	public Text gameover;
	public Text restart;
	public Text mainMenu;
	public GameObject restartgo;
	public GameObject menugo;
	public Text highScore;
//	CircleCollider2D circleCollider;
//	SphereCollider sphereCollider;
	public GameObject[] leftCut;
	public GameObject[] rightCut;


	public GameObject[] splashReference;
	private Vector3 randomPos;
	private Text scoreReference;
	int pos;

	void Start ()
	{
		cam = Camera.main;
		rb = GetComponent<Rigidbody>();
//		sphereCollider = GetComponent<SphereCollider>();
		pos = Random.Range (0, 3);
		scoreReference = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
		randomPos = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-4.5f, 3.5f), 5f);
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Moved) {
				StartCutting ();
			}

			if (touch.phase == TouchPhase.Ended) {
				StopCutting ();
			}
			if (isCutting) {
				UpdateCut ();
			}

		}
		if (Input.GetMouseButtonDown(0))
		{
			StartCutting();
		} else if (Input.GetMouseButtonUp(0))
		{
			StopCutting();
		}

		if (isCutting)
		{
			UpdateCut();
		}

		highScore.text = PlayerPrefs.GetInt ("highScore").ToString ();




	}


	void UpdateCut ()
	{
		Vector3 newPosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,5f));
		newPosition.z = 1f;
//		newPosition.z = 5f;
		rb.position = newPosition;

//		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
//		if (velocity > minCuttingVelocity)
//		{
//			sphereCollider.enabled = true;
//		} else
//		{
//			sphereCollider.enabled = false;
//		}

		previousPosition = newPosition;
	}

	void StartCutting ()
	{
		isCutting = true;
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,5f));
		Debug.Log ("Blade"+previousPosition.z.ToString());
//		previousPosition.z = 1f;
//		previousPosition.z = 5f;
//		sphereCollider.enabled = false;
	}

	void StopCutting ()
	{
		isCutting = false;
		currentBladeTrail.transform.SetParent(null);
		Destroy(currentBladeTrail, 2f);
//		sphereCollider.enabled = false;
	}


	IEnumerator Level1()
	{
//		print(Time.time);
		yield return new WaitForSeconds(0.1f);
		SceneManager.LoadScene("level1");
//		print(Time.time);
	}

	IEnumerator Exit1()
	{
		//		print(Time.time);
		yield return new WaitForSeconds(0.1f);
		Application.Quit();
		//		print(Time.time);
	}

	IEnumerator MainMenu()
	{
		//		print(Time.time);
		yield return new WaitForSeconds(0.1f);
		SceneManager.LoadScene("home screen");
		//		print(Time.time);
	}

	void OnCollisionEnter(Collision other)

	{
		GameObject left, right;
		Vector3 temp1;
		Vector3 throwForceleft = new Vector3(-1 ,0, 0);
		Vector3 throwForceright = new Vector3(1 ,0, 0);
		if (other.gameObject.tag == "New Game") {
			temp1 = new Vector3(other.transform.position.x,other.transform.position.y,other.transform.position.z);
			left = Instantiate (leftCut [1], temp1, leftCut [0].transform.rotation);
			right = Instantiate (rightCut [1], temp1, rightCut [0].transform.rotation);
			left.GetComponent<Rigidbody>().AddForce (throwForceleft, ForceMode.VelocityChange);
			right.GetComponent<Rigidbody>().AddForce (throwForceright, ForceMode.VelocityChange);
			Destroy(other.gameObject);
			GetComponent<AudioSource> ().Play ();
			StartCoroutine(Level1());

			return;
		}


		if (other.gameObject.tag == "Restart") {
			temp1 = new Vector3(other.transform.position.x,other.transform.position.y,other.transform.position.z);
			left = Instantiate (leftCut [1], temp1, leftCut [0].transform.rotation);
			right = Instantiate (rightCut [1], temp1, rightCut [0].transform.rotation);
			left.GetComponent<Rigidbody>().AddForce (throwForceleft, ForceMode.VelocityChange);
			right.GetComponent<Rigidbody>().AddForce (throwForceright, ForceMode.VelocityChange);
			Destroy(other.gameObject);
			GetComponent<AudioSource> ().Play ();
			StartCoroutine(Level1());
			return;
		}

		if (other.gameObject.tag == "Main Menu") {
			throwForceleft = new Vector3(1 ,0, 0);
			throwForceright = new Vector3(-1 ,0, 0);
			temp1 = new Vector3(other.transform.position.x,other.transform.position.y,other.transform.position.z);
			left = Instantiate (leftCut [2], temp1, leftCut [0].transform.rotation);
			right = Instantiate (rightCut [2], temp1, rightCut [0].transform.rotation);
			left.GetComponent<Rigidbody>().AddForce (throwForceleft, ForceMode.VelocityChange);
			right.GetComponent<Rigidbody>().AddForce (throwForceright, ForceMode.VelocityChange);
			Destroy(other.gameObject);
			GetComponent<AudioSource> ().Play ();
			StartCoroutine(MainMenu());
			return;
		}


		if (other.gameObject.tag == "Exit") {
			temp1 = new Vector3(other.transform.position.x,other.transform.position.y,other.transform.position.z);
			left = Instantiate (leftCut [0], temp1, leftCut [0].transform.rotation);
			right = Instantiate (rightCut [0], temp1, rightCut [0].transform.rotation);
			left.GetComponent<Rigidbody>().AddForce (throwForceleft, ForceMode.VelocityChange);
			right.GetComponent<Rigidbody>().AddForce (throwForceright, ForceMode.VelocityChange);
			Destroy(other.gameObject);
			GetComponent<AudioSource> ().Play ();
			StartCoroutine(Exit1());
			return;
		}

		Debug.Log ("COLLIDE" + other.gameObject.tag);
//		if(other.gameObject.tag == "Line")
//		{
//			//			Camera.main.GetComponent<AudioSource>().Play();
//			Destroy(gameObject);
//		}
		temp1 = new Vector3(other.transform.position.x,other.transform.position.y,other.transform.position.z);
		int cutpos;
		if (other.gameObject.tag == "Apple") {
			cutpos = 0;
		} else if (other.gameObject.tag == "Kiwi") {
			cutpos = 1;
		} else if (other.gameObject.tag == "Strawberry") {
			cutpos = 2;
		} else {
			FruitSpawner.instance.CancelInvoke ("SpawnFruit");
			gameover.GetComponent<Text>().enabled = true;
			restart.GetComponent<Text>().enabled = true;
			mainMenu.GetComponent<Text>().enabled = true;
			restartgo.gameObject.SetActive (true);
			menugo.gameObject.SetActive (true);
//			Destroy(other.gameObject);
			other.rigidbody.freezeRotation = true;
			other.rigidbody.useGravity = false;
			Camera.main.GetComponent<AudioSource>().Pause();
			other.gameObject.GetComponent<AudioSource>().Play ();
			return;
		}
		left = Instantiate (leftCut [cutpos], temp1, leftCut [0].transform.rotation);
		right = Instantiate (rightCut [cutpos], temp1, rightCut [0].transform.rotation);

		if (cutpos != 2) {
			throwForceleft = new Vector3(-1 ,0, 0);
			throwForceright = new Vector3(1 ,0, 0);
		} else {
			throwForceleft = new Vector3(1 ,0, 0);
			throwForceright = new Vector3(-1 ,0, 0);
		}

		left.GetComponent<Rigidbody>().AddForce (throwForceleft, ForceMode.VelocityChange);
		right.GetComponent<Rigidbody>().AddForce (throwForceright, ForceMode.VelocityChange);
		Destroy(other.gameObject);
		GetComponent<AudioSource> ().Play ();
		pos = Random.Range (0, 3);
		randomPos = new Vector3(temp1.x,temp1.y, 5f);
		GameObject splash = Instantiate(splashReference[pos], randomPos, transform.rotation);
		Destroy (splash, 1f);




		/* Update Score */

		scoreReference.text = (int.Parse(scoreReference.text) + 1).ToString();
		if(PlayerPrefs.HasKey("highScore")) {
			if(int.Parse(scoreReference.text) > PlayerPrefs.GetInt("highScore"))
				PlayerPrefs.SetInt("highScore",int.Parse(scoreReference.text));
		}
		else {
			PlayerPrefs.SetInt("highScore",int.Parse(scoreReference.text));
		}

	}

}