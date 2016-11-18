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
	float timer;
	public float speed;
	private bool hit;

	//test
	public float s,t,g,holder;
	// Renderer
	public MeshRenderer rend;

	// Show indicator for this projectile?
	public bool showIndicator;

	// Use this for initialization
	void Start () {

		hit = false;

		//get ridid body and players positions
		body = GetComponent<Rigidbody>();
		target = (GameObject.FindWithTag("Player").transform);

		g = 9.8f / (speed*speed);
		timer = 0;

		ThrowBall();

		showIndicator = true;
	}

	//if too low destroy
	void Update (){

		//calculate value for gravity per frame
		timer = 1 / Time.deltaTime;
	
		Vector3 grav;
		grav.x = 0;
		grav.y = g / timer;
		grav.z = 0;

		//reduce t velocity by gravity per frame
		if (!hit) {
			body.velocity = body.velocity - grav;
		}

		//rotation
		Debug.DrawRay (transform.position, -body.velocity, Color.red);
		transform.rotation = Quaternion.LookRotation (-body.velocity);
	}
		
	void ThrowBall(){

		//get distance
		distance = target.position - transform.position;
	
		//set the x velocity to that distance (will get to position in 1 second divide by public variable for time if needing to be changed)
		vel.x = distance.x / speed ;
		vel.z = distance.z / speed ;

		//variables
		s = distance.y;
		theta = 45;
		sinTheta = Mathf.Sin (theta * Mathf.Deg2Rad) ;
		t = 1;

		//equations
		holder = s/speed + ( (0.5f*speed) * g);
		holder = holder/sinTheta;
		holder = holder*sinTheta;
		vel.y = holder;

		//add velocity
		body.velocity = vel;
	}

	void OnCollisionEnter(Collision collision)
	{
		// Stop emmmissvnos partecle
		gameObject.GetComponent<ParticleSystem> ().enableEmission = false;

		if (collision.collider.tag == "GameController") 
		{
			ControllerVelocity controller = collision.gameObject.GetComponent<ControllerVelocity> ();

			Vector3 newDir = collision.collider.transform.position - transform.position;
			newDir.y = controller.GetVelocity ().y;
			newDir.x = controller.GetVelocity ().x;
			newDir.z = controller.GetVelocity ().z;

			body.AddForce(newDir, ForceMode.VelocityChange);

			showIndicator = false;
		}
//		if (collision.collider.tag == "GameController") 
//		{
//			Vector3 newDir = collision.collider.transform.position - transform.position;
//			body.AddForce(-newDir*2, ForceMode.VelocityChange);
//			showIndicator = false;
//		}
	}
}