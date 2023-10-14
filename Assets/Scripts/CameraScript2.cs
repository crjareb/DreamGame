using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript2 : MonoBehaviour
{
    public Transform player;
    public float offsetY;
    public bool nextPassage;

    GameObject camera2;
    // Start is called before the first frame update
    void Start()
    {

        nextPassage = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (nextPassage == false)
        {
            Vector3 pos = transform.position;
            pos.y = player.position.y + offsetY;
            if (pos.y > transform.position.y)
            {
                transform.position = pos;

            }

        }
        else
        {

            Instantiate(camera2, transform.position, Quaternion.identity) ;

        }
        
        
    }
}
