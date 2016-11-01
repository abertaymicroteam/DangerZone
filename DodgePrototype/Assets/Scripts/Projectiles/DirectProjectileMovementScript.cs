using UnityEngine;
using System.Collections;

public class DirectProjectileMovementScript : MonoBehaviour 
{
	// Movement variables
	public float speed;		//movement speed of ball
	bool moving;			//if ball is moving or not
	Vector3 direction;		//direction vector of projectile
	Rigidbody rigB;			//rigidbody
	float lifeTime;			//time since the projectile was spawned

	// Renderer
	public MeshRenderer rend;

	// Use this for initialization
	void Start ()
    {
		rend = GetComponent<MeshRenderer>();
		rend.material.SetColor ("_Color", Color.blue);
		rigB = this.GetComponent<Rigidbody> ();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		// Init movement variables
		lifeTime = 0.0f;

		// Get mesh renderer and colour direct projectiles blue
		rend = GetComponent<MeshRenderer>();
		rend.material.SetColor ("_Color", Color.blue);

		//calculate direction ( target position - current position)
		direction.Set(player.transform.position.x -rigB.position.x, player.transform.position.y -rigB.position.y,player.transform.position.z -rigB.position.z);            
		direction.Normalize ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		// Move positively in the X axis
		Vector3 Vel = direction * speed;
		rigB.velocity = Vel;
		lifeTime += Time.deltaTime;


		// Check if out of playable area on positive X side
		if (lifeTime > 3)
		{
			Destroy(gameObject);
		}
	}
}
