using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
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
    private Rigidbody2D rb2d;

    //directions
    Vector3 targetPos;
    Vector3 thisPos;


    //target
    public GameObject Alice;
    

    void Start()
    {
        //initialize the timer and position vectors and rb2d
        currTimer = timer;
        thisPos = transform.position;
        targetPos = Alice.transform.position;
        rb2d = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        currTimer = currTimer - Time.deltaTime; //subtract time in seconds each frame

        if(currTimer<= 0)
        {
            targetPos =  Alice.transform.position; // get position of target object
            currTimer = timer; //return timer to normal state
        }

        thisPos = transform.position;
        

        Vector3 targetDirection = targetPos - thisPos;
        targetDirection.Normalize();
        rb2d.velocity = targetDirection * speed;



    }

    //if player comes into contact with player level restart ✅

    void OnTriggerEnter2D(Collider2D other)

    {

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        
    }
}
