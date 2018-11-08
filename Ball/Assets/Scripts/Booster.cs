using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{

    public Vector2 scroll;
    public int boostForce;

    void Update()
    {
        AnimateTexture();
    }

    void Boost(GameObject go)
    {
        go.GetComponent<Rigidbody>().velocity = Vector3.zero;
        go.GetComponent<Rigidbody>().AddForce(transform.forward * boostForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Boost(other.gameObject);
        }
    }
    
    void AnimateTexture()
    {
        Vector2 offset = new Vector2(Time.time * scroll.x, Time.time * scroll.y);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
