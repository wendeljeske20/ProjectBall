using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public GameObject father;
    public GameObject[] platformer;
    public float rotationX;
    void Update()
    {
        rotationX = GetComponent<Rigidbody>().angularVelocity.x;
        for (int i = 0; i < platformer.Length; i++)
        {
            platformer[i].transform.rotation = father.transform.rotation;
        }
        if (GetComponent<Rigidbody>().angularVelocity.x < -0.1)
        {
            father.transform.Translate(new Vector3(0, 0, rotationX * 3) * Time.deltaTime);
        }
        else if (GetComponent<Rigidbody>().angularVelocity.x > 0.1)
        {
            father.transform.Translate(new Vector3(0, 0, rotationX * 3) * Time.deltaTime);
        }
    }
    
}
