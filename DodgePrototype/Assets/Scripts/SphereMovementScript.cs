using UnityEngine;
using System.Collections;

public class SphereMovementScript : MonoBehaviour 
{
	// Movement variables
	public float speed;
	bool moving;
	Vector3 direction;
	public Vector3 defPos;
	Rigidbody rigB;
	float tempX;
	float tempZ;

	// Use this for initialization
	void Start ()
    {

		rigB = this.GetComponent<Rigidbody> ();

		// Init movement variables
		moving = true;

		//calculate direction ( target position - current position)
		direction.Set(-rigB.position.x, 0.0f,-rigB.position.z);            

	}
	
	// Update is called once per frame
	void Update ()
    {
		// Move positively in the X axis
		if (moving) 
		{
			Vector3 Vel = direction * speed;
			rigB.velocity = Vel;
		}

		// Check if out of playable area on positive X side
		if (transform.position.x > 2)
		{
			// Reset to default position
			//Destroy(gameObject);
		}
	}
}
