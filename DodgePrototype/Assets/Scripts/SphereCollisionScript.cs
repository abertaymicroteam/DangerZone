using UnityEngine;
using System.Collections;

public class SphereCollisionScript : MonoBehaviour {

	//Change

	// Collision variables
	bool collided;				//flag for collision
	enum Colour {Blue, Red};	//colours for testing
	Colour thisColour;			//^^
	public PlayerHealth player;
	// Renderer
	public MeshRenderer rend;

	// Use this for initialization
	void Start () 
	{
		// Init collision variables
		thisColour = Colour.Blue;
		collided = false;

		// Get mesh renderer
		rend = GetComponent<MeshRenderer>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		// If collided, destroy object and deal damage to player
		//if not set color to blue 
		if (collided) {
			player.TakeDamage (12.5f);
			Destroy (gameObject);
		} 
		else if (!collided) {
			thisColour = Colour.Blue;
		}

		//rend selected color
		switch (thisColour) 
		{
		case Colour.Blue:
			rend.material.SetColor ("_Color", Color.blue);
			break;

		case Colour.Red:
			rend.material.SetColor ("_Color", Color.red);
			break;
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
