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
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// Check for collision event
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player") 
		{
			Destroy (gameObject);
		}
	}
}
