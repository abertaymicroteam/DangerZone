using UnityEngine;
using System.Collections;

public class HomingBall : MonoBehaviour {

	private Rigidbody body;
	private Transform target;

	public float speed = 1;
	public float rotationSpeed = 200;

	void Start () {
	
		target = GameObject.FindWithTag("Player").transform;
		body = GetComponent<Rigidbody>();
	}
	
	void Update () {
	
		// Calculate direction needed to travel in
		Vector3 direction = Vector3.Normalize(transform.position - target.transform.position);
		
		// Angle needed to turn to go in that direction
		float angle = Vector3.Cross(direction, transform.right).z;
		
		// Set angular velocity and forward velocity
		body.angularVelocity.Set(rotationSpeed * angle, rotationSpeed * angle, rotationSpeed * angle);
		body.velocity = transform.right * speed;

		// Despawn is too far away
		if (Vector3.Distance(transform.position, target.position) > 10){
			Destroy (this.gameObject);
		}
	}
}