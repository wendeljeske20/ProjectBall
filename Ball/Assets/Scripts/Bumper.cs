﻿using System.Collections;
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
    public bool bumped, reloading;
    public float resetSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        
        if (bumped)
        {
            nextReloadTime++;
        }
        else
        {
            startPosition = _base.transform.position + (_base.transform.up / 3.5f);
            if (transform.position != startPosition)
            {
                RestorePosition();
            }
            else
            {
                reloading = false;
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
        reloading = true;
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
        if (collision.gameObject.tag == "Player" && !reloading)
        {
           // collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Bump();
        }
    }
}