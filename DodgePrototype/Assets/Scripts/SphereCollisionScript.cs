using UnityEngine;
using System.Collections;

public class SphereCollisionScript : MonoBehaviour {

	//Change

	// Collision variables
	bool collided;
	enum Colour {Blue, Red};
	Colour thisColour;

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
		// If collided, change colour
		if (collided) {
			thisColour = Colour.Red;
		} 
		else if (!collided) {
			thisColour = Colour.Blue;
		}

		switch (thisColour) 
		{
		case Colour.Blue:
			rend.material.SetColor ("_Color", Color.blue);
			break;

		case Colour.Red:
			rend.material.SetColor ("_Color", Color.red);
			break;
		}

		// Check if out of playable area on positive X side
		if (transform.position.x > 2)
		{
			// Reset flag
			collided = false;
			// Reset to default position
			transform.position.Set(-5.0f, 2.0f, 0.0f);
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
