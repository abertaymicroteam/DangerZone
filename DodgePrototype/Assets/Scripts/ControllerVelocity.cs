using UnityEngine;
using System.Collections;

public class ControllerVelocity : MonoBehaviour {

	Vector3 lastFrame, thisFrame;
	public Vector3 Velocity;
	// Use this for initialization
	void Start () {
		thisFrame = transform.position;
	}

	// Update is called once per frame
	void Update () {
		lastFrame = thisFrame;
		thisFrame = transform.position;
		Velocity = thisFrame - lastFrame;
		Velocity.x = Velocity.x * (1 / Time.deltaTime);
		Velocity.y = Velocity.y * (1 / Time.deltaTime);
		Velocity.z = Velocity.z * (1 / Time.deltaTime);
	}

	public Vector3 GetVelocity(){
		return Velocity;
	}
}
