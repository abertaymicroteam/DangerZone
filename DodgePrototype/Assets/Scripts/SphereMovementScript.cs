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

	public enum ProjectileType { direct, arced}; //definition of projectile type
	public ProjectileType TypeDef;



	/******** physics ********/
	public float force, mass, acceleration, velI, velB, time;


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
			if (TypeDef == ProjectileType.direct) {
				Vector3 Vel = direction * speed;
				rigB.velocity = Vel;
			}
			if (TypeDef == ProjectileType.arced) {
				
				Vector3 Vel;
				Vel.x = direction.x * speed;
				Vel.y = direction.y + Mathf.Cos (time) * direction.x;
				time += Time.deltaTime;
				Vel.z = direction.z * speed;
				//arced calculations
	
				//= direction * speed;
				rigB.velocity = Vel;
			}
		}

		// Check if out of playable and delete
		if (transform.position.x > 15 || transform.position.x < -15 || transform.position.z > 15 || transform.position.z < -15)
		{
			Destroy(gameObject);
		}

	}
}
