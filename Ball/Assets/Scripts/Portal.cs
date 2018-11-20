using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    public string teleportSceneName;
    public bool startTeleport = false;
    public int existenceTime = 0;
	
    void Update()
    {
        if (startTeleport)
        {
            existenceTime++;
            if(existenceTime >= 1000)
            {
                Destroy(gameObject);
            }
        }

    }

    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(teleportSceneName);
        }
    }

    
}
