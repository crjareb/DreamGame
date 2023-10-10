using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawner : MonoBehaviour
{
    //timer for shots from enemy
    public float timer = 3; 
    float currTimer;
    Vector2 direction;
    public GameObject bullet;



    // Start is called before the first frame update
    void Start()
    {
        currTimer = timer;

    }

    // Update is called once per frame
    void Update()
    {
        currTimer = currTimer - Time.deltaTime;

        if (currTimer <= 0)
        {

            Instantiate(bullet, transform.position, Quaternion.identity);
            currTimer = timer;
        }


    }
}
