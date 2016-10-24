using UnityEngine;
using System.Collections;

public class SphereCollisionScript : MonoBehaviour {

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

	// Destroy on collision with player
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player") 
		{
			Destroy (gameObject);
		}
	}
}
