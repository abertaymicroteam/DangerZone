using UnityEngine;
using System.Collections;

public class SphereCollisionScript : MonoBehaviour {

	//Change

	// Collision variables
	bool collided;
	// Renderer
	public MeshRenderer rend;

	// Use this for initialization
	void Start () 
	{
		// Init collision variables
		collided = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Check if out of playable area on positive X side
		if (collided) {
			Destroy (gameObject);
		}
	}

	// Check for collision event
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player") 
		{
			collided = true;
		}
	}
}
