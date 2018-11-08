using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour {

    public GameObject player;

    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            //transform.LookAt(player.transform, hit.normal);
        }
       
    }
}
