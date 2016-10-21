using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	//players health
	float playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Check for collision between player and a projectile
	//decreaseplayers health by 1/8th
	void OnTriggerEnter(Collider other){
		if (other.tag == "Projectile") {
			playerHealth -= 12.5f;
		}
	}
}
