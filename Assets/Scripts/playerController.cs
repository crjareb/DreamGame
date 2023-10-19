using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool isGrounded = false;
    public LayerMask groundLayer;
    private bool isWalking = false;
    private bool isFalling = false;

    private SpriteRenderer spriteRenderer;
    private Vector3 velocityRef = Vector3.zero;

    public Animator animator;

    [Header("Movement Settings")]
    public float speed;
    public float maxSpeed;
    [Range(0, .3f)][SerializeField] private float movementSmoothing = .05f;

    [Header("Jump Settings")]
    public float jumpForce;
    public float groundRayLength;
    public float fallMultiplier;
    public float lowJumpMultiplier;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isGrounded = false;
        
    }



    void Update()
    {
        Move();
        UpdateGrounding();
        IsWalking();
        Jump();
        JumpGravityChange();
        FlipSprites();
        
    }

    private void Move()
    {
        Vector3 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb2d.velocity.y);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref velocityRef, movementSmoothing, maxSpeed);
    }

    private void IsWalking()
    {
        if (isGrounded && Mathf.Abs(rb2d.velocity.x) > 0.01) 
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if (!isGrounded && rb2d.velocity.y < -0.01)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isFalling", isFalling);
    }

    private void FlipSprites()
    {
        if (rb2d.velocity.x > 0.01)
        {
            spriteRenderer.flipX = false;
        }
        else if (rb2d.velocity.x < -0.01)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void JumpGravityChange()
    {
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2d.velocity.y > 0 && !(Input.GetKey(KeyCode.Space)))
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Jump()
    {
        Vector2 vel = rb2d.velocity;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            vel.y = jumpForce;
        }

        rb2d.velocity = vel;
    }

    void UpdateGrounding()
    {

        Vector3 rayStart = transform.position + Vector3.up * groundRayLength;

        RaycastHit2D hitDown = Physics2D.Raycast(rayStart, Vector3.down, groundRayLength * 2, groundLayer);

        Debug.DrawLine(rayStart, rayStart + Vector3.down * groundRayLength * 2, Color.red);

        if (hitDown.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        animator.SetBool("isGrounded", isGrounded);
    }

}
