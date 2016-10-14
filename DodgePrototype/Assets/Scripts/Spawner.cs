using UnityEngine;
using System.Collections;

/// <Summary>
/// Spawner.
/// 
/// Spawn balls at a random location with a public variable for the rate of spawn
/// 
/// </summary>
/// 
public class Spawner : MonoBehaviour {

	public GameObject Projectile; //object to me fired
	public float counter;		  //initial time between spawns
	float setTime;				  //varied reset timer for spawn
	bool spawn;					  //if an object is to be spawned 
	Vector3 SpawnLocation;		  //the spawn location
	float tempX;				  //used for calculation position on circle for x positoin
	float tempZ;				  //used for calculation position on circle for z position
	float rand;					  //shared angle
	public float radius;		  //distance from player for spawning objects

	// Use this for initialization
	void Start () {
		//set timer to max time seed random
		setTime = counter;
		Random.seed = (int)System.DateTime.Now.Ticks;
	}

	// Update is called once per frame
	void Update () {



		//set the timer to count in real time when it reaches 0 spawn a projectile and reset to new time
		counter -= Time.deltaTime;
		if (counter < 0) {
			spawn = true;
			counter = setTime;
		}

		//when the timer has run out spawn a ball at a random location and set the flag to spawn as false;
		if (spawn) {

			//calculate a random angle and use to find random spawn location on a circle around the player
			//instantiate projectile prefab at this location
			rand = Random.Range (0.0f, 2 * Mathf.PI);
			tempX = 0 +  Mathf.Cos (rand) * radius;
			tempZ = 0 +  Mathf.Sin (rand) * radius;
			SpawnLocation.Set (tempX, 1, tempZ);

			Instantiate(Projectile, SpawnLocation, Quaternion.identity);
			spawn = false;
		}
	}
}
