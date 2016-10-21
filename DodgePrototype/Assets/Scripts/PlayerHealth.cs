using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health; //player health percentage
	bool collided;
	// Use this for initialization
	// initialize health at 100%
	void Start () {
		health = 100;	
	}
	
	// Update is called once per frame
	void Update () {
		
		// reduce player health
		if (collided) {
			health -= 10;
			collided = false;
		}

		
	}

	//check for collision event

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Projectile") 
		{
			collided = true;
		}
	}
}
