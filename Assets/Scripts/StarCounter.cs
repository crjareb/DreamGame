using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class StarCounter : MonoBehaviour
{
    public int counter;
    private Animator animator;
    public AudioSource myAudioSource;
     

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Star>() != null)
        {
            //counter++;
            animator = other.GetComponent<Animator>();
            animator.SetBool("PlayerCollide", true);
            myAudioSource.Play();

        }
    }
}
        

  
