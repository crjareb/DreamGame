using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    //if it collides with Alice - Alice dies
    //follow Alice using a delayed position vector
    //instantiated after alice crossses a threshold in the game

    //child GUN object which shoots bullets every x seconds

    //timer for updating enemy movement direction 
    public float timer = 1; //how frequently to update position vector enemy is moving in
    float currTimer;

    //for changing enemy movement
    public float speed;

    //directions
    Vector3 targetPos;
    Vector3 thisPos;


    //target
    public GameObject Alice;

    public bool isActive;
    public Camera cam1;
    

    void Start()
    {
        //initialize the timer and position vectors and rb2d
        currTimer = timer;
        thisPos = transform.position;
        targetPos = Alice.transform.position;
        isActive = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(Alice.transform.position.x>transform.position.x)
        {
            isActive = true;
        }

        if (isActive == true)
        {
            currTimer = currTimer - Time.deltaTime; //subtract time in seconds each frame

            if (currTimer <= 0)
            {
                targetPos = Alice.transform.position; // get position of target object
                currTimer = timer; //return timer to normal state
            }

            thisPos = transform.position;


            Vector3 targetDirection = targetPos - thisPos;
            targetDirection.Normalize();

            transform.position += new Vector3(targetDirection.x, targetDirection.y, 0) * speed * Time.deltaTime;

        }
        



    }

    //if player comes into contact with player level restart ✅

    void OnTriggerEnter2D(Collider2D other)

    {
        if (isActive == true)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }

        }
        

        
    }
}
