using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject DirectProjectile; // direct projectile prefab
	public GameObject ArcedProjectile;  //arced  projectile prefab
	public float SpawnDelay;		  //initial time between spawns
	private float setTime;				 	  //varied reset timer for spawn
	Spawner[] spawners;				  //avaliable spawners

	//set timer to max time seed random
	//generate array of spawner objects
	//place projectlie types onto array
	void Start () {
		
		Random.seed = (int)System.DateTime.Now.Ticks;
		spawners = FindObjectsOfType (typeof(Spawner)) as Spawner[];
		setTime = 2;

	}
	
	//set the timer to count in real time when it reaches 0 spawn a projectile
	//from a random spawner and reset to new time
	void Update () {

		SpawnDelay -= Time.deltaTime;
		if (SpawnDelay <= 0) {

			spawners [Random.Range (0, spawners.Length)].Spawn ();
			//select a random projectil at a random spawner
//			switch (Random.Range (0, 2)) {
//			case 0:
//				spawners [Random.Range (0, spawners.Length)].Spawn (ArcedProjectile);
//				break;
//			case 1:
//				spawners [Random.Range (0, spawners.Length)].Spawn (DirectProjectile);
//				break;
//
//			}

			SpawnDelay = setTime;
		}
	}
}
