using UnityEngine;
using System.Collections;

public class SphereMovementScript : MonoBehaviour 
{
	// Movement variables
	public float speed;			//movement speed of ball
	bool moving;				// ???	
	Vector3 direction;			//vector for ball to travel
	public Vector3 defPos;		//position to spawn
	Rigidbody rigB;				//rigid body for object

	// Use this for initialization
	void Start ()
    {

		rigB = this.GetComponent<Rigidbody> ();

		// Init movement variables
		moving = true;

		//calculate direction vector ( player position - current position )
		direction.Set(GameObject.FindGameObjectWithTag("Player").transform.position.x -rigB.position.x, 
			GameObject.FindGameObjectWithTag("Player").transform.position.y -rigB.position.y ,
			GameObject.FindGameObjectWithTag("Player").transform.position.z-rigB.position.z);            


	}
	
	// Update is called once per frame
	void Update ()
    {
		// Move along vector
		if (moving) 
		{
			Vector3 Vel = direction * speed;
			rigB.velocity = Vel;
		}

		// Check if out of playable and delete
		if (transform.position.x > 15 || transform.position.x < -15 || transform.position.z > 15 || transform.position.z < -15)
		{
			Destroy(gameObject);
		}

	}
}
