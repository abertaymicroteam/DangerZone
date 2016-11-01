using UnityEngine;
using System.Collections;

/// <Summary>
/// 
/// Spawner.
/// Spawn balls at position of gameObject
/// 
/// To be looked at:
/// gameObject.transform.position.y is not returning the correct value
/// 
/// Resolved:
/// Issue was parent object was offset from 0,0 
/// 
/// </summary>
/// 
public class Spawner : MonoBehaviour {


	public Vector3 SpawnLocation;  


	void Start () {

	}
		
	void Update () {


	}


	public void Spawn(GameObject Projectile){

		SpawnLocation.Set (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		Instantiate (Projectile, SpawnLocation, Quaternion.identity);

	}
		
}
