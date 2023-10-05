using System.Collections;
using UnityEngine;

public class CollisionAndAnimation : MonoBehaviour
{
    public Animator animationComponent; // Reference to the Animation component
    public float delayBeforeAnimation = 0.5f; // Delay in seconds before triggering the animation

    private bool hasCollided = false; // Flag to track if collision has occurred

    // This method is called when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && collision.gameObject.CompareTag("DeadLog")) // Replace "YourTag" with the appropriate tag
        {
            hasCollided = true;
       
            // Wait for the specified delay before triggering the animation
            StartCoroutine(PlayAnimationAndDestroy());
        }
    }

    // Coroutine to play the animation and destroy the object
    private IEnumerator PlayAnimationAndDestroy()
    {
        yield return new WaitForSeconds(delayBeforeAnimation);

     
        // Trigger the animation (assuming you have set up an animation on the animationComponent)
        if (animationComponent != null)
        {
            animationComponent.Play("BreakLog", 0); // Replace with your animation name if needed
        }

        // Destroy the object after the animation is complete (you can adjust the delay if needed)
        Destroy(gameObject);
    }
}