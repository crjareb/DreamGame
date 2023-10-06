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

    [Header("Level Achievement Settings")]
    public int numberOfStars;
    public GameObject finalStar;

    private void Start()
    {
        counter = 0;
        myAudioSource = GetComponent<AudioSource>();
        finalStar.SetActive(false);
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

        if (counter >= numberOfStars)
        {
            finalStar.SetActive(true);
        }

        if (other.GetComponent<FinalStar>() != null)
        {
            //animator = other.GetComponent<Animator>();
            //animator.SetBool("PlayerCollide", true);
            Invoke("LoadNextScene", 3f);
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
        

  
