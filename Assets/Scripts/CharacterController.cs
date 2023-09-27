using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void UpdateGrounding()
    {
        
        Vector3 rayStart = transform.position + Vector3.down * groundRayLength;
        Vector3 rayStartLeft = transform.position + Vector3.down * groundRayLength + Vector3.left * groundRaySpread;
        Vector3 rayStartRight = transform.position + Vector3.down * groundRayLength + Vector3.right * groundRaySpread;


        RaycastHit2D hitDown = Physics2D.Raycast(rayStart, Vector2.down, groundRayLength * 2, groundLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(rayStartLeft, Vector2.left, groundRayLength * 2, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(rayStartRight, Vector2.right, groundRayLength * 2, groundLayer);
        
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
