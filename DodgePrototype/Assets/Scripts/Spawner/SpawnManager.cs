using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject DirectProjectile; // direct projectile prefab
	public GameObject ArcedProjectile;  //arced  projectile prefab
	public float SpawnDelay;		  //initial time between spawns
	float setTime;				 	  //varied reset timer for spawn
	Spawner[] spawners;				  //avaliable spawners
<<<<<<< HEAD
	GameObject[] projectiles;
=======
	public GameObject DirectProjectile;	  //direct projectie prefab
	public GameObject ArcedProjectile;		  //arced projectile prefab
>>>>>>> origin/Projectiles

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

<<<<<<< HEAD
			spawners [Random.Range(0,spawners.Length)].Spawn(DirectProjectile);
=======
			spawners [Random.Range(0,spawners.Length)].Spawn(ArcedProjectile);
			//spawners [1].Spawn(ArcedProjectile); // for test purposes one spawner active
>>>>>>> origin/Projectiles
			SpawnDelay = setTime;
		}
	}
}
