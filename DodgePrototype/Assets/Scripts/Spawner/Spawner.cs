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

<<<<<<< HEAD
	bool spawn;					  		//if an object is to be spawned 
	Vector3 SpawnLocation;		 		//the spawn location
	int SpawnCounter;					//number of projectiles spawned
=======
	public Vector3 SpawnLocation;  //the spawn location
	public float holdup;

	//Set Spawnlocation and instantiate projectile
	public void Spawn(GameObject Projectile){
		holdup = transform.position.y;
		SpawnLocation.Set (gameObject.transform.position.x,  gameObject.transform.position.y , gameObject.transform.position.z);
		Instantiate(Projectile, SpawnLocation, Quaternion.identity);
	}
>>>>>>> origin/Projectiles

	void Start () {

	}
		
	void Update () {
<<<<<<< HEAD

	}


	public void Spawn(GameObject Projectile){

		SpawnLocation.Set (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		Instantiate (Projectile, SpawnLocation, Quaternion.identity);
=======
	
>>>>>>> origin/Projectiles
	}
		
}
