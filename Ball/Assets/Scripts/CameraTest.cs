using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour {

    public GameObject player;
    public Transform offset;
    bool colliding;

    void Update()
    {
       
        if (!colliding)
        {
            transform.position = Vector3.MoveTowards(transform.position, offset.position, 5);
            transform.rotation = offset.rotation;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        colliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }
}
