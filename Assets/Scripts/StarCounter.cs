using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class StarCounter : MonoBehaviour
{
    public static int counter;
    private Animator animator;
    private AudioSource myAudioSource;
    public GameObject levelBounds;

    [Header("Level Achievement Settings")]
    public int numberOfStars;
    public GameObject finalStar;
    public GameObject platform;

    private void Start()
    {
        counter = 0;
        myAudioSource = GetComponent<AudioSource>();
        finalStar.SetActive(false);
        levelBounds.SetActive(true);
    }

    private void Update()
    {
        if (counter >= numberOfStars)
        {
            finalStar.SetActive(true);  //final star only shows up when other stars are collected
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
            levelBounds.SetActive(false);                   //player can fall
            animator = platform.GetComponent<Animator>();   //platform falls
            animator.SetTrigger("PlatformFall");
            Invoke("LoadNextScene", 3f);                    //load next scene - completed level
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
        

  
