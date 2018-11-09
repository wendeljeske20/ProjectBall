using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbine : MonoBehaviour {

    public int force;

	void Start () {
		
	}
	
	
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * force);
        }
    }
}
