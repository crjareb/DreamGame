using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class StarCounter : MonoBehaviour
{
    public int counter;
    private Animator animator;
    private AudioSource myAudioSource;
    //public Sprite[] starSprites;
    //public Sprite explosion;
    //public WaitForSeconds switchTime;

    private void Start()
    {
        counter = 0;
        myAudioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Star>() != null)
        {
            counter++;
            myAudioSource.Play();
            animator = other.GetComponent<Animator>();
            animator.SetBool("PlayerCollide", true);

        }
    }
}
        

  
