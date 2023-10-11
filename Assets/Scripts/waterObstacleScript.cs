using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class waterObstacleScript : MonoBehaviour
{
    // Start is called before the first frame update

    //Animate the water -- make it shift from side to side 
    //Continuously and slowly move up (based on how long the player needs to complete the level and the top of the camera)
    //On contact with player --> Restart the level


    //Move the water up 


    public float distance; //I want to move this distance in x amount of time
    public float timer; //I want this movement to take place over this amount of time

    public float smoothness; //how often I want to update the position in a second

    float perSecond;
    float movesPerSecond;
    float moveTimer;
    float howFar;
    Vector2 newPos;

    float distanceCounter;

    //Move the water from side to side

    public float moveDistance; // The distance the platform will move side to side
    public float moveSpeed;    // The speed at which the platform moves

    private float initialX;           // The initial X-position of the platform

    

    private bool movingRight = true;  // Flag to determine if the platform is moving right or left
    float targetX2;

    void Start()
    {

        //moving the water up 
        
        perSecond = distance / timer; //how far I want to move per second
        movesPerSecond = 1f / smoothness;
        howFar = perSecond / smoothness;
        moveTimer = movesPerSecond;

        distanceCounter = 0;

        //moving the water from side to side

        //startPos = transform.position;
        initialX = transform.position.x;
        targetX2 = initialX + moveDistance;
    }

    // Update is called once per frame
    void Update()
    {
       //for moving watr up

        moveTimer -= Time.deltaTime;
        if(moveTimer<= 0 && distanceCounter<=distance)
        {
            newPos.y = transform.position.y + howFar;
            distanceCounter += howFar;
            newPos.x = transform.position.x;
            transform.position = newPos;
            moveTimer = movesPerSecond;
        }

        //for moving the water from side to side

        Vector3 currentPos = transform.position;


        // Calculate the target position based on the current direction (right or left)
        float currTargetX;

        if (movingRight)
        {
            currTargetX = targetX2; //either target to the right
        }
        else
        {
            currTargetX = initialX; //or initial position of the object
        }

        // Calculate the new position for the platform
        float newX = Mathf.MoveTowards(transform.position.x, currTargetX, moveSpeed * Time.deltaTime);

        // Update the platform's position
        transform.position = new Vector3(newX, currentPos.y, currentPos.z);

        // If the platform has reached its target position, change direction
        if (Mathf.Abs(newX - currTargetX) < 0.01f)
        {
            //this works after a while but not immediately
            movingRight = !movingRight;
        }


    }

    //On collision with player, restart level

    void OnTriggerEnter2D(Collider2D other)

    {

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }


    }
}
