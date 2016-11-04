using UnityEngine;
using System.Collections;

public class DirectProjectileMovementScript : MonoBehaviour 
{
	// Movement variables
	public float speed;		//movement speed of ball
	bool moving;			//if ball is moving or not
	Vector3 direction;		//direction vector of projectile
	Rigidbody rigB;			//rigidbody
	Vector3 Vel;			// Final velocity

	// Renderer
	public MeshRenderer rend;

	// Show indicator for this projectile?
	public bool showIndicator;

	// Use this for initialization
	void Start ()
    {
		rend = GetComponent<MeshRenderer>();
		rend.material.SetColor ("_Color", Color.blue);
		rigB = this.GetComponent<Rigidbody> ();
		GameObject player = GameObject.FindGameObjectWithTag("Player");

		// Get mesh renderer and colour direct projectiles blue
		rend = GetComponent<MeshRenderer>();
		rend.material.SetColor ("_Color", Color.blue);

		//calculate direction ( target position - current position)
		direction.Set(player.transform.position.x -rigB.position.x, player.transform.position.y -rigB.position.y,player.transform.position.z -rigB.position.z);            
		direction.Normalize ();

		//add velocity to the projectile
		Vel = direction * speed;
		rigB.velocity = Vel;

		// Show projectile by default
		showIndicator = true;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "GameController") 
		{
			//rigB.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
			rigB.AddForce(-Vel*4, ForceMode.VelocityChange);
			showIndicator = false;
		}	
	}
}
