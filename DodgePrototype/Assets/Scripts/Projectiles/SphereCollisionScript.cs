using UnityEngine;
using System.Collections;

public class SphereCollisionScript : MonoBehaviour {

<<<<<<< HEAD
	//Change

	// Collision variables
	bool collided;
=======
>>>>>>> origin/Projectiles
	// Renderer
	public MeshRenderer rend;

	// Use this for initialization
	void Start () 
	{
<<<<<<< HEAD
		// Init collision variables
		collided = false;
=======
		
>>>>>>> origin/Projectiles
	}
	
	// Update is called once per frame
	void Update () 
	{
<<<<<<< HEAD
		// Check if out of playable area on positive X side
		if (collided) {
			Destroy (gameObject);
		}
=======
		
>>>>>>> origin/Projectiles
	}

	// Destroy on collision with player
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player") 
		{
			Destroy (gameObject);
		}
	}
}
