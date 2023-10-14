using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;
    public GameObject Alice;

    Vector3 playerPos;
    Vector3 thisPos;
    public GameObject smile;
    private SpriteRenderer spriteRenderer;

    Vector3 otherSide;
    Vector3 defaultPos;

    float offset;

    public float timer;
    float currTimer;

    public bool isActive;
    public Camera cam1;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        smile = transform.parent.gameObject;

        otherSide = transform.localPosition;
        otherSide.x = -transform.localPosition.x;
        defaultPos = transform.localPosition;
        currTimer = timer;
        isActive = false;


    }

    // Update is called once per frame
    void Update()
    {

        if(Alice.transform.position.x > transform.position.x)
        {
            isActive = true;
        }

        if (isActive)
        {
            //Change gun positions so that it points at alice 
            playerPos = Alice.transform.position;
            thisPos = transform.position;
            Vector3 directionPos = playerPos - thisPos;

            //float offset;

            if (directionPos.x < 0)
            {
                spriteRenderer.flipX = true;
                transform.localPosition = otherSide;
                transform.SetParent(smile.transform);
                offset = 180;

            }
            else
            {
                spriteRenderer.flipX = false;
                transform.localPosition = defaultPos;
                transform.SetParent(smile.transform);
                offset = 0;
            }

            //recalculate direction
            playerPos = Alice.transform.position;
            thisPos = transform.position;
            directionPos = playerPos - thisPos;

            directionPos.Normalize();

            //rotate gun in direction of alice
            float angle = Mathf.Atan2(directionPos.y, directionPos.x);

            // Set the rotation of the gun, keeping the z-axis rotation at 0 degrees
            transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg - offset, Vector3.forward);

            {
                currTimer = currTimer - Time.deltaTime;

                if (currTimer <= 0)
                {

                    Instantiate(bullet, transform.position, Quaternion.identity);
                    currTimer = timer;
                }


            }

        }

    }
        
}


