using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float timer = 7; //how many seconds between shots
    float currTimer;
    public GameObject bullet;
    public GameObject Alice;

    Vector3 playerPos;
    Vector3 thisPos;
    public GameObject smile;
    private SpriteRenderer spriteRenderer;

    Vector3 otherSide;
    Vector3 defaultPos;
    Vector3 ogDirection;



    void Start()
    {
        currTimer = timer;
        spriteRenderer = GetComponent<SpriteRenderer>();
        smile = transform.parent.gameObject;

        otherSide = transform.localPosition;
        otherSide.x = -transform.localPosition.x;
        defaultPos = transform.localPosition;


    }

    // Update is called once per frame
    void Update()
    {
        currTimer -= Time.deltaTime; //decrease by seconds between frames 

        //Change gun positions so that it points at alice 
        playerPos  = Alice.transform.position;
        thisPos = transform.position;
        Vector3 directionPos = playerPos - thisPos;

        //float offset;

        if (directionPos.x < 0)
        {
            spriteRenderer.flipX = true;
            transform.localPosition = otherSide;
            transform.SetParent(smile.transform);
            ogDirection = Vector3.left;

        }
        else 
        {
            spriteRenderer.flipX = false;
            transform.localPosition = defaultPos;
            transform.SetParent(smile.transform);
            ogDirection = Vector3.right;
        }

        //recalculate direction
        playerPos = Alice.transform.position;
        thisPos = transform.position;
        directionPos = playerPos - thisPos;

        directionPos.Normalize();

        //rotate gun in direction of alice
        float angle = Mathf.Atan2(directionPos.y, directionPos.x) * Mathf.Rad2Deg;

        // Set the rotation of the gun, keeping the z-axis rotation at 0 degrees
        transform.eulerAngles = new Vector3(0, 0, angle);


        if (currTimer <= 0)
        {

            //make a bullet

            Instantiate(bullet, transform.position, Quaternion.identity);
        }


    }
}


