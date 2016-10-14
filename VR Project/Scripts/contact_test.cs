using UnityEngine;
using System.Collections;

public class contact_test : MonoBehaviour {

    void OnCollisionEnter(Collision col){

        Destroy(this.gameObject);
    }
}
