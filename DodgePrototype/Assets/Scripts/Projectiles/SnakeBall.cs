using UnityEngine;
using System.Collections;

public class SnakeBall : MonoBehaviour {

	private Transform target;

	public int frequency;
	public float velocity;
	public float amplitude;

	private float initTime;
	private float dist;

	private Vector3 temp;

	void Start () {

		initTime = Time.timeSinceLevelLoad;
		target = (GameObject.FindWithTag("Player").transform);
		dist = Vector3.Distance (transform.position, target.position);
	}

	void FixedUpdate () {

		float timeSinceInitialization = Time.timeSinceLevelLoad - initTime;

		temp.x += velocity;
		temp.y = amplitude * Mathf.Sin ((float)frequency / 2);

		transform.position = temp;
	}
}