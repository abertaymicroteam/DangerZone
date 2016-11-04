using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	//players health
	public float playerHealth;

	// Object containers
	Text text;

	// Use this for initialization
	void Start () {
		playerHealth = 100.0f;

		text = GameObject.FindObjectOfType<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "Health";
	}

	//Check for collision between player and a projectile
	//decreaseplayers health by 1/8th
	void OnTriggerEnter(Collider other){
		if (other.tag == "Projectile") {
			playerHealth -= 12.5f;
		}
	}
}
