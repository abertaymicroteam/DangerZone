using UnityEngine;
using System.Collections;

public class SpawnerRotation : MonoBehaviour {


	public float rotation; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 
		transform.RotateAround (transform.position, Vector3.up, rotation * Time.deltaTime);
	}
}
