using UnityEngine;
using System.Collections;

public class SphereMovementScript : MonoBehaviour 
{
	// Movement variables
	float speed;
	bool moving;
	Vector3 direction;
	public Vector3 defPos;
	Rigidbody rigB;

	// Use this for initialization
	void Start ()
    {
		// Initialise position
		defPos.Set(-5.0f, 2.0f, 0.0f);
		transform.position.Set(defPos.x, defPos.y, defPos.z);

		// Init movement variables
		speed = 1.0f;
		moving = true;
		direction.Set(1.0f, 0.0f, 0.0f);
		rigB = this.GetComponent<Rigidbody> ();
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
			rigB.MovePosition(defPos);
		}
	}
}
