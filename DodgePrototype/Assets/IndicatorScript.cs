using UnityEngine;
using System.Collections;

public class IndicatorScript : MonoBehaviour {

	float lockRot;

	// Use this for initialization
	void Start () 
	{
		lockRot = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Lock rotatoin on x and y axes to 0
		transform.rotation = Quaternion.Euler (lockRot, lockRot, transform.rotation.eulerAngles.z);
	}
}
