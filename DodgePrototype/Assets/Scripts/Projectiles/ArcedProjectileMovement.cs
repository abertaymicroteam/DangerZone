using UnityEngine;
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

	//objects
	private Rigidbody body; 	//projectile
	private Transform target;	//player

	//maths variables
	public float opp , adj, hyp;	//for maths 
	public float theta;				//angle
	public float sinTheta;
	public float rotation;			//angle to rotate by TEsting
	private float gravity = 9.8f;	//gravity
	public float velocity;			//veloctity 
	public Vector3 direction;		//direction of ball normal vector
	public Vector3 vel;
	public Vector3 distance;


	//test
	public float s,t,g,holder;
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

	/*****old******/
	/*void ThrowBall (){

		/*
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
		direction.y = (theta / 90.0f);

		// Calculate velocity required to hit target (Range equation)
		//Range assuming both objects y = 0
		//float 
		//velocity = Mathf.Sqrt(gravity * adj / (Mathf.Sin(theta ))); //previous code do no delete!!!
		//Range equation taking change in y into account ( i have checked this has been entered correctly) 
		velocity = (1/(Mathf.Cos(theta))) * Mathf.Sqrt(Mathf.Abs(0.5f*(gravity*Mathf.Pow(adj,2)) /  (hyp*Mathf.Tan(theta) - opp))); 

		// Move projectile (Direction of throw * Velocity required to hit target)
		//vel.y = direction*velocity;

		//cos and sin 45 are equal multiply distance by x y and z velocities
		//neds fixed
		body.velocity = direction * (velocity );
		*/
	/*}*/

	void ThrowBall(){

		//get distance
		distance = target.position - transform.position;
	
		//set the x velocity to that distance (will get to position in 1 second divide by public variable for time if needing to be changed)
		vel.x = distance.x;
		vel.z = distance.z;

		s = distance.y;
		theta = 45;
		sinTheta = Mathf.Sin (theta * Mathf.Deg2Rad) ;
		t = 1;
		g = -4.9f;
		holder = s - g;
		holder = holder/sinTheta;
		holder = holder*sinTheta;
		vel.y = holder;


		body.velocity = vel;


	}
}