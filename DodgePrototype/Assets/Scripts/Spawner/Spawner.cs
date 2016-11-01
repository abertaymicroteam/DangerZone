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
	public GameObject Projectile1;
	public GameObject Projectile2;
	public float nextProjectile;


	void Start () {

		nextProjectile = Random.Range (0, 2);
	}
		
	void Update () {


	}


	public void Spawn(){

		SpawnLocation.Set (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);



		switch ((int)nextProjectile) {
			case 0:
				Instantiate (Projectile1, SpawnLocation, Quaternion.identity);
				break;
			case 1:
				Instantiate (Projectile2, SpawnLocation, Quaternion.identity);
				break;
		
		}

		nextProjectile = Random.Range (0, 2);

	}
		
}
