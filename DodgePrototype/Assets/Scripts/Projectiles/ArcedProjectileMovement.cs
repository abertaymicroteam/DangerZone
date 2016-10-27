﻿using UnityEngine;
using System.Collections;

/// <Needing Fixed>
/// 
/// currently when run spawner will instantiate projectiles above the spawners position not at the same position
/// (errors may be found in spawner code)
/// this script takes in the players position at 1.5 not 1 which throws off calculations
/// note:
/// public variables used for testing during play
/// needs to be tried out on the vive to see if this resolves errors
/// 
/// issue resolved:
/// error found parent objects camera rig and spawn manager were offset from 0,0
/// 
/// to look at:
/// still unable to hit player when changing y location
/// 
/// </Needing Fixed>

public class ArcedProjectileMovement : MonoBehaviour {

<<<<<<< HEAD
	// Movement variables
	public float speed;		//movement speed of ball
	bool moving;			//if ball is moving or not
	Vector3 direction;		//direction vector of projectile
	Rigidbody rigB;			//rigidbody
	float lifeTime;
	public MeshRenderer rend;

	// Use this for initialization
	void Start ()
	{
		rend = GetComponent<MeshRenderer>();
		rend.material.SetColor ("_Color", Color.red);
		rigB = this.GetComponent<Rigidbody> ();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		// Init movement variables
		moving = true;
		lifeTime = 0.0f;

		//calculate direction ( target position - current position)
		direction.Set(player.transform.position.x -rigB.position.x, player.transform.position.y -rigB.position.y,player.transform.position.z -rigB.position.z);            
		direction.Normalize ();
	}

	// Update is called once per frame
	void Update ()
	{
		// Move positively in the X axis
		if (moving) 
		{
			Vector3 Vel = direction * speed;
			rigB.velocity = Vel;
			lifeTime += Time.deltaTime;
		}

		// Check if out of playable area on positive X side
		if (lifeTime > 3)
		{
			Destroy(gameObject);
		}
=======
	//objects
	private Rigidbody body; 	//projectile
	private Transform target;	//player

	//maths variables
	public float opp , adj, hyp;	//for maths 
	public float theta;				//angle
	public float rotation;			//angle to rotate by TEsting
	private float gravity = 9.8f;	//gravity
	public float velocity;			//veloctity 
	public Vector3 direction;		//direction of ball normal vector
	public Vector3 vel;

	// Renderer
	public MeshRenderer rend;

	// Use this for initialization
	void Start () {

		// Get mesh renderer and colour arced projectiles red
		rend = GetComponent<MeshRenderer>();
		rend.material.SetColor ("_Color", Color.red);

		//get ridid body and players positions
		body = GetComponent<Rigidbody>();
		target = (GameObject.FindWithTag("Player").transform);

		ThrowBall();
	}

	//if too low destroy
	void Update (){

		if (transform.position.y < -10) {
			Destroy (this.gameObject);
		}
	}

	void ThrowBall (){

		// Calculate direction and distance of target and normalize the vector
		direction = (target.position - transform.position);
		direction.Normalize();

		//calulate values for equiations 
		// op = change in y
		// adj = length of line along xz plane
		// hyp = length of line straight from spawner to target
		opp = target.transform.position.y - transform.position.y;
		adj = Mathf.Sqrt(Mathf.Pow(body.transform.position.x - target.transform.position.x,2)+Mathf.Pow(body.transform.position.z - target.transform.position.z,2));
		hyp = Mathf.Sqrt (Mathf.Pow (opp, 2) + Mathf.Pow (adj, 2));

		//rotate so that the angle is 45 degrees from a line directly between spawner and player
		rotation = (Mathf.Asin(opp/adj) * Mathf.Rad2Deg);
		//keep at 45 for testing
		theta = 45.0f;//+ rotation;
		//?????
		direction.y = (theta / 90.0f);

		// Calculate velocity required to hit target (Range equation)
		//Range assuming both objects y = 0
		//float velocity = Mathf.Sqrt(gravity * distance / (Mathf.Sin(2 * theta * Mathf.Deg2Rad))); //previous code do no delete!!!
		//Range equation taking change in y into account ( i have checked this has been entered correctly) 
		velocity = (1/(Mathf.Cos(theta))) * Mathf.Sqrt(Mathf.Abs(0.5f*(gravity*Mathf.Pow(adj,2)) /  (adj*Mathf.Tan(theta) + opp))); 

		// Move projectile (Direction of throw * Velocity required to hit target)
		//vel.y = direction*velocity;

		//cos and sin 45 are equal multiply distance by x y and z velocities
		//neds fixed
		body.velocity = direction * (velocity * Mathf.Sin(theta));
>>>>>>> origin/Projectiles
	}
}