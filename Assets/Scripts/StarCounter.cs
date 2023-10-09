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
    public GameObject finalStar;

    private void Start()
    {
        counter = 0;
        myAudioSource = GetComponent<AudioSource>();
        finalStar.SetActive(false);
    }

    private void Update()
    {
        if (counter >= 5)           
        {
            finalStar.SetActive(true);  //final star only shows up when 5 stars are collected
            finalCount = counter;
            counter = 0;                //so this code stops running
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Star>())
        {
            myAudioSource.Play();
            animator = other.GetComponent<Animator>();
            animator.SetBool("PlayerCollide", true);
        }

        if (other.GetComponent<FinalStar>())
        {
            animator = other.GetComponent<Animator>();
            animator.SetBool("PlayerCollideFinal", true);
            TransitionScene.instance.Transition();
        }
    }

    private void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
        

  
