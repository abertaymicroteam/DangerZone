using UnityEngine;
using System.Collections;

public class ThrowBall : MonoBehaviour {

	private Rigidbody body;
	private Transform target;

	private float gravity = 9.8f;

	public bool showIndicator = true;

	// Use this for initialization
	void Start () {

		body = GetComponent<Rigidbody>();
		target = (GameObject.FindWithTag("Player").transform);
		
		Throw();
	}

	void Update (){

		// Despawn is too far away
		if (Vector3.Distance(transform.position, target.position) > 10){
			Destroy (this.gameObject);
		}
	}

	void Throw (){

		// Calculate direction and distance of target
		Vector3 direction = (target.position - transform.position).normalized;
		float distance = Vector3.Distance(transform.position, target.transform.position);

		// Decide a firing angle based on distance (for now use 45)
		float theta = 45.0f;
		direction.y = (theta / 90.0f);

		// Calculate velocity required to hit target (Range equation)
		float velocity = Mathf.Sqrt(gravity * distance / (Mathf.Sin(2 * theta * Mathf.Deg2Rad)));

		// Direction of throw * Velocity required to hit target
		body.AddForce(direction * velocity * 100.0f);
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