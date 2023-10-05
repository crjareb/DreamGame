using System.Collections;
using UnityEngine;

public class CollisionAndAnimation : MonoBehaviour
{
    private Animator animationComponent; // Reference to the Animation component
    public float delayBeforeAnimation = 0.5f; // Delay in seconds before triggering the animation

    private bool hasCollided = false; // Flag to track if collision has occurred

    // This method is called when a collision occurs


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasCollided && collision.gameObject.CompareTag("DeadLog")) // Replace "YourTag" with the appropriate tag
        {
            hasCollided = true;
            animationComponent = collision.GetComponent<Animator>();
            animationComponent.SetBool("PlayerCollide", true);

            // Wait for the specified delay before triggering the animation
            //StartCoroutine(PlayAnimationAndDestroy());
        }
    }

}