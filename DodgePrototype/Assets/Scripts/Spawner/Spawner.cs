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

	public GameObject Projectile; //object to me fired
	bool spawn;					  //if an object is to be spawned 
	Vector3 SpawnLocation;		  //the spawn location

	public void Spawn(){
		spawn = true;
	}

	void Start () {
		
	}
		
	void Update () {

		//Set Spawnlocation and instantiate projectile
		if (spawn) {
			
			SpawnLocation.Set (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			Instantiate(Projectile, SpawnLocation, Quaternion.identity);
			spawn = false;
		}
	}


}
