using UnityEngine;
using System.Collections;

/// <Summary>
/// Spawner.
/// 
/// Spawn balls at position of gameObject with a public variable for the rate of spawn
/// 
/// </summary>
/// 
public class Spawner : MonoBehaviour {

	bool spawn;					  //if an object is to be spawned 
	Vector3 SpawnLocation;		  //the spawn location

	//Set Spawnlocation and instantiate projectile
	public void Spawn(GameObject Projectile){
		SpawnLocation.Set (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		Instantiate(Projectile, SpawnLocation, Quaternion.identity);
	}

	void Start () {
		
	}
		
	void Update () {
	
	}
		
}
