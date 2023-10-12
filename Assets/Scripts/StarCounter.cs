using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class StarCounter : MonoBehaviour
{
    public static int counter;
    public static int finalCount;
    private Animator animator;
    private AudioSource myAudioSource;

    private void Start()
    {
        counter = 0;
        myAudioSource = GetComponent<AudioSource>();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Star>())
        {
            myAudioSource.Play();
            animator = other.GetComponent<Animator>();
            animator.SetBool("PlayerCollide", true);    //animate star burst
        }

        if (other.GetComponent<BigStar>())
        {
            animator = other.GetComponent<Animator>();
            animator.SetBool("PlayerCollideFinal", true);   //animate final star burst
            TransitionScene.instance.Transition();      //transition to next scene
        }
    }
}
        

  
