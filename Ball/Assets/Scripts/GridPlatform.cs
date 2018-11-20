using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlatform : MonoBehaviour {

    public GameObject arrow;
    public int timer = 0;
    public int rotationTime = 0;
    public float rotationY = 0;
    bool stop = false;
	void Start () {
		
	}
	
	void Update () {
        if (!stop)
        {
            timer++;
        }
        rotationY = arrow.transform.eulerAngles.y;
        if(timer >= rotationTime)
        {
            timer = 0;
            arrow.transform.eulerAngles = new Vector3(-90, rotationY + 90, 0);
            
        }
    }
    private void OnCollisionStay(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            stop = true;
            transform.position += -arrow.transform.right / 8;
            //GetComponent<Rigidbody>().AddForce(-arrow.transform.right / 8);
        }
    }
    private void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player")
        {
            stop = false;
        }
    }
}
