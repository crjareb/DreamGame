using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraToggler : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam1;
    public Camera cam2;
    public GameObject player;
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (player.transform.position.y>53)
        {
            cam1.enabled = false;
            cam2.enabled = true;
        }
        
    }
}
