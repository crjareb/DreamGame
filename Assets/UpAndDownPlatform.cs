
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float moveDistance = 2.0f; // The distance the platform will move up and down
    public float moveSpeed = 2.0f;    // The speed at which the platform moves

    private Vector3 startPos;         // The starting position of the platform
    private float initialY;           // The initial Y-position of the platform

    private bool movingUp = true;      // Flag to determine if the platform is moving up or down

    void Start()
    {
        startPos = transform.position;
        initialY = startPos.y;
    }

    void Update()
    {
        // Calculate the target position based on the current direction (up or down)
        float targetY = movingUp ? initialY + moveDistance : initialY;

        // Calculate the new position for the platform
        float newY = Mathf.MoveTowards(transform.position.y, targetY, moveSpeed * Time.deltaTime);

        // Update the platform's position
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // If the platform has reached its target position, change direction
        if (Mathf.Approximately(newY, targetY))
        {
            movingUp = !movingUp;
        }
    }
}