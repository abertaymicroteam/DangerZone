using UnityEngine;
using System.Collections;

public class StraightBall : MonoBehaviour {

	private Rigidbody body;
	private Transform target;

	public float speed = 1;
	private Vector3 direction;

	public bool showIndicator = true;

	// Use this for initialization
	void Start(){

		body = GetComponent<Rigidbody>();
		target = GameObject.FindGameObjectWithTag("Player").transform;

		// calculate direction (target position - current position)
		direction = Vector3.Normalize(target.transform.position - transform.position);
		body.velocity = direction * speed;
		transform.rotation = Quaternion.LookRotation (-body.velocity);
	}
	
	// Update is called once per frame
	void Update(){

		// rotate to face the player and draw a ray facing the opposite direction from movement
		Debug.DrawRay (transform.position, -body.velocity, Color.red);
		transform.rotation = Quaternion.LookRotation (-body.velocity);

		// Despawn is too far away
		if (Vector3.Distance(transform.position, target.position) > 10){
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision collision){
		
		if (collision.collider.tag == "GameController"){
			
			Debug.Log ("Collision!");
			ControllerVelocity controller = collision.gameObject.GetComponent<ControllerVelocity> ();

			Vector3 newDirection = controller.GetVelocity ();

			body.AddForce(newDirection, ForceMode.VelocityChange);
		}

		// don't show indicators after a collision has occured
		showIndicator = false;
	}
}