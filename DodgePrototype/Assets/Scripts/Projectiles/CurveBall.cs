using UnityEngine;
using System.Collections;

public class CurveBall : MonoBehaviour {

	private float distance;
	private Transform target;
	private Vector3 direction;

	void Start () {
	
		target = GameObject.FindWithTag("Player").transform;
		distance = Vector3.Distance(transform.position, target.position);
		direction = target.position - transform.position;
	}
	
	void Update () {
	
		Transform nextPosition;
		
		//float offset;
		//nextPosition = transform.position + (direction * speed) + (transform.right * offset);

		// Despawn is too far away
		if (Vector3.Distance(transform.position, target.position) > 10){
			Destroy (this.gameObject);
		}
	}
}