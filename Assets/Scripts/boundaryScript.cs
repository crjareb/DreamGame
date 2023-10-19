using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaryScript : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public GameObject player;
    void Start()
    {

        transform.SetParent(cam1.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > 53)
        {
            transform.SetParent(cam2.transform);
        }
    }
}
