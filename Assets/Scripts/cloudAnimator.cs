using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cloudAnimator : MonoBehaviour
{
    public Transform cameraView;
    public float parallaxScale;
    public float offset;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = (cameraView.position.x + offset) * parallaxScale;
        transform.position = pos;
    }


}
