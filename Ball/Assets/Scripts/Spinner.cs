using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public GameObject father;
    public GameObject[] platformer;
    Rigidbody rb;

    public float speed;
    public float rotationX;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rotationX = rb.angularVelocity.x;

        for (int i = 0; i < platformer.Length; i++)
        {
            platformer[i].transform.rotation = father.transform.rotation;
        }
        if (rb.angularVelocity.x < -0.1)
        {
            father.transform.Translate(new Vector3(0, 0, rotationX * speed) * Time.deltaTime);
        }
        else if (rb.angularVelocity.x > 0.1)
        {
            father.transform.Translate(new Vector3(0, 0, rotationX * speed) * Time.deltaTime);
        }
    }

}
