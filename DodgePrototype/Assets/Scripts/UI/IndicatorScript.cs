using UnityEngine;
using System.Collections;

public class IndicatorScript : MonoBehaviour {

	float lockRot;
	RectTransform transf;

	// Use this for initialization
	void Start () 
	{
		transf = GetComponent<RectTransform> ();
		lockRot = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Lock rotation on x and y axes to 0
		transf.localRotation = Quaternion.Euler (lockRot, lockRot, transform.rotation.eulerAngles.z);
	}
}
