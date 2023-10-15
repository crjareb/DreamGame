using UnityEngine;

public class PlatformMovementSide : MonoBehaviour
{
    public float moveDistance = 2.0f; // The distance the platform will move side to side
    public float moveSpeed = 2.0f;    // The speed at which the platform moves

    private Vector3 startPos;         // The starting position of the platform
    private float initialX;           // The initial X-position of the platform

    private bool movingRight = true;  // Flag to determine if the platform is moving right or left

    void Start()
    {
        startPos = transform.position;
        initialX = startPos.x;
    }

    void Update()
    {
        // Calculate the target position based on the current direction (right or left)
        float targetX = movingRight ? initialX + moveDistance : initialX - moveDistance;

        // Calculate the new position for the platform
        float newX = Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * Time.deltaTime);

        // Update the platform's position
        transform.position = new Vector3(newX, startPos.y, startPos.z);

        // If the platform has reached its target position, change direction
        if (Mathf.Approximately(newX, targetX))
        {
            movingRight = !movingRight;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
