using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public GameObject _base;
    Vector3 startPosition;
    Rigidbody rb;
    public int force;
    public int reloadTime;
    int nextReloadTime;
    public bool bumped;
    public float resetSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Boost();
        //}
        if (bumped)
        {
            nextReloadTime++;
        }
        else
        {
            startPosition = _base.transform.position + (_base.transform.up / 4);
            if (transform.position != startPosition)
            {
                RestorePosition();
            }

        }
        if (nextReloadTime == reloadTime)
        {
            Reload();
        }

    }

    void Reload()
    {
        ResetForces();
        bumped = false;
        nextReloadTime = 0;
    }

    void RestorePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPosition, resetSpeed * Time.deltaTime);
    }

    void ResetForces()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }


    void Bump()
    {
        ResetForces();
        rb.AddForce(transform.up * force);
        bumped = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" && !bumped)
        {
            Bump();
        }
    }
}