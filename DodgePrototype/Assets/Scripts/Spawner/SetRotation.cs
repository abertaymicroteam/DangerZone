using UnityEngine;
using System.Collections;

public class SetRotation : MonoBehaviour {

	Transform target;  //player location
	public float speed;	//rotation speed
	GameObject player;	//player
	public Vector3 targetDir;

	// Use this for initialization
	void Start () {

		//set the target transform to the players location
		player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;


	}
	
	// Update is called once per frame
	void Update () {


		float opp = target.transform.position.y - transform.position.y;
		float adj = Mathf.Sqrt(Mathf.Pow(transform.position.x - target.transform.position.x,2)+Mathf.Pow(transform.position.z - target.transform.position.z,2));
		float hyp = Mathf.Sqrt (Mathf.Pow (opp, 2) + Mathf.Pow (adj, 2));

		//calculate the direction of the target and rotate towards it
		targetDir = target.position - transform.position;
		if (GetComponentInParent<Spawner> ().nextProjectile > 0) {
			targetDir.y = adj * Mathf.Tan (45 * Mathf.Deg2Rad); 
		}
		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0f);
		Debug.DrawRay (transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation (newDir);

	}
}
