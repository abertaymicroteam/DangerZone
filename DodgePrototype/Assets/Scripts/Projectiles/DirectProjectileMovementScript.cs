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

	//rotation
	Transform target;
	public Vector3 targetDir;

	//testing
	public Vector3 newDir;

	// Renderer
	public MeshRenderer rend;

	// Show indicator for this projectile?
	public bool showIndicator;

	// Use this for initialization
	void Start ()
    {
		rend = GetComponent<MeshRenderer>();
		rigB = this.GetComponent<Rigidbody> ();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;

		//calculate direction ( target position - current position)
		direction.Set(player.transform.position.x -rigB.position.x, player.transform.position.y -rigB.position.y,player.transform.position.z -rigB.position.z);            
		direction.Normalize ();

		//add velocity to the projectile
		Vel = direction * speed;
		rigB.velocity = Vel;

		// Show projectile by default
		showIndicator = true;

		//calculate the direction of the target and rotate towards it
		targetDir = target.position - transform.position;
		transform.rotation = Quaternion.LookRotation (-rigB.velocity);

	}
	
	// Update is called once per frame
	void Update ()
    {
		Debug.DrawRay (transform.position, -rigB.velocity, Color.red);
		transform.rotation = Quaternion.LookRotation (-rigB.velocity);
	}

	void OnCollisionEnter(Collision collision)
	{
		// Stop particle emission
		gameObject.GetComponent<ParticleSystem> ().enableEmission = false;

		if (collision.collider.tag == "GameController") 
		{
			ControllerVelocity controller = collision.gameObject.GetComponent<ControllerVelocity> ();

			newDir = collision.collider.transform.position - transform.position;
			newDir.y = controller.GetVelocity ().y;
			newDir.x = controller.GetVelocity ().x;
			newDir.z = controller.GetVelocity ().z;

			rigB.AddForce(newDir, ForceMode.VelocityChange);

			showIndicator = false;
		}
	}
}
