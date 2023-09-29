using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    public float jumpForce;
    private bool isGrounded = false;
    public LayerMask groundLayer;
    public float groundRayLength;
    public float groundRaySpread;
    private SpriteRenderer spriteRenderer;
 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Vector2 vel = rb2d.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;

        UpdateGrounding();

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            vel.y = jumpForce;
        }

        rb2d.velocity = vel;



        if (vel.x > 0.01)
        {
            spriteRenderer.flipX = false;
        }
        else if (vel.x < -0.01)
        {
            spriteRenderer.flipX = true;
        }



        //character death
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void UpdateGrounding()
    {

        Vector3 rayStart = transform.position + Vector3.up * groundRayLength;
        Vector3 rayStartLeft = transform.position + Vector3.up * groundRayLength + Vector3.left * groundRaySpread;
        Vector3 rayStartRight = transform.position + Vector3.up * groundRayLength + Vector3.right * groundRaySpread;


        RaycastHit2D hitDown = Physics2D.Raycast(rayStart, Vector3.down, groundRayLength * 2, groundLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(rayStartLeft, Vector3.left, groundRayLength * 2, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(rayStartRight, Vector3.right, groundRayLength * 2, groundLayer);

        Debug.DrawLine(rayStart, rayStart + Vector3.down * groundRayLength * 2, Color.red);

        if (hitDown.collider != null || hitLeft.collider != null || hitRight.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
