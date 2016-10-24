using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public float SpawnDelay;		  //initial time between spawns
	float setTime;				 	  //varied reset timer for spawn
	Spawner[] spawners;				  //avaliable spawners
	public GameObject DirectProjectile;	  //direct projectie prefab
	public GameObject ArcedProjectile;		  //arced projectile prefab

	//set timer to max time seed random
	//generate array of spawner objects
	void Start () {
	
		setTime = SpawnDelay;
		Random.seed = (int)System.DateTime.Now.Ticks;

		spawners = FindObjectsOfType (typeof(Spawner)) as Spawner[];
	}
	
	//set the timer to count in real time when it reaches 0 spawn a projectile
	//from a random spawner and reset to new time
	void Update () {

		SpawnDelay -= Time.deltaTime;
		if (SpawnDelay < 0) {

			spawners [Random.Range(0,spawners.Length)].Spawn(ArcedProjectile);
			SpawnDelay = setTime;
		}
	}
}
