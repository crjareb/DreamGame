using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Animate clouds so that they float across screen


public class cloudAnimator : MonoBehaviour
{
    //public float cloudSpeed = 3.0f;
    //Vector3 direction = new Vector3 (-1, 0, 0);
    public Transform cameraView;
    public float parallaxScale;
    public float offset;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = (cameraView.position.x + offset) * parallaxScale;
        transform.position = pos;
        //transform.Translate(direction * Time.deltaTime * cloudSpeed);
    }


}
