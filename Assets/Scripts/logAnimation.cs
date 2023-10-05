using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logAnimation : MonoBehaviour
{
    public float timer = 1; //How long do you want the animation to last for 
    public Sprite[] breakFrames; //animation frames for the logs
    public float frames = 3; // how big the array is 
    float framesPerSecond;
    float frameTimer;
    int currentFrameIndex = 0;

    SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        //Set up timer for frames
        //frames = breakFrames.Length;
        framesPerSecond = frames / timer; // how long you want each frame to last for
        frameTimer = 1f / framesPerSecond; //how long you want each frame to last for in terms of frames instead of seconds
        currentFrameIndex = 0;

        mySpriteRenderer.sprite = breakFrames[0]; //this object --> 1st sprite in the array
    }

    // Update is called once per frame
    void Update()
    {
        frameTimer -= Time.deltaTime; //Decrease count by how much time has passed between frames

        if (frameTimer <= 0) //when frame timer is less than or equal to 0
        {
            currentFrameIndex++; //go to next frame
            if (currentFrameIndex >= breakFrames.Length) //or destroy object
            {
                Destroy(transform.gameObject);
                return;
            }
            mySpriteRenderer.sprite = breakFrames[currentFrameIndex];
            frameTimer = (1f / framesPerSecond);
        }


    }
}
