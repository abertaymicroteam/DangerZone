using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health; //player health percentage

	// Use this for initialization
	// initialize health at 100%
	void Start () {
		//health = 100;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//reduce players health 
	public void TakeDamage(float damage){
		health = health - 10;
	}
}
