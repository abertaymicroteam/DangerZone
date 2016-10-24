using UnityEngine;
using System.Collections;

public class ArcedProjectileMovement : MonoBehaviour {

	private Rigidbody body;
	private Transform target;

	float opp, adj;
	public float theta;
	float change;

	private float gravity = 9.8f;

	// Renderer
	public MeshRenderer rend;

	// Use this for initialization
	void Start () {

		// Get mesh renderer and colour arced projectiles red
		rend = GetComponent<MeshRenderer>();
		rend.material.SetColor ("_Color", Color.red);

		body = GetComponent<Rigidbody>();
		target = (GameObject.FindWithTag("Player").transform);



		ThrowBall();
	}

	void Update (){

		if (transform.position.y < -10) {
			Destroy (this.gameObject);
		}
	}

	void ThrowBall (){

		// Calculate direction and distance of target
		Vector3 direction = (target.position - transform.position).normalized;
		float distance = Vector3.Distance(transform.position, target.transform.position);

		// Decide a firing angle based on distance (for now use 45)
		opp = body.transform.position.y - target.transform.position.y;
		adj = Mathf.Abs (body.transform.position.x - target.transform.position.x);
		theta = 45.0f + (Mathf.Atan(opp/adj));
		direction.y = (theta / 90.0f);

		// Calculate velocity required to hit target (Range equation)
		float velocity = Mathf.Sqrt(gravity * distance / (Mathf.Sin(2 * theta * Mathf.Deg2Rad)));

		// Direction of throw * Velocity required to hit target
		body.AddForce(direction * velocity * 50.0f);
	}
}