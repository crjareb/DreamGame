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
    public GameObject levelBounds;

    [Header("Level Achievement Settings")]
    public int numberOfStars;
    public GameObject finalStar;
    public GameObject platform;

    private void Start()
    {
        counter = 0;
        myAudioSource = GetComponent<AudioSource>();
        finalStar.SetActive(true);
        levelBounds.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Star>())
        {
            myAudioSource.Play();
            animator = other.GetComponent<Animator>();
            animator.SetBool("PlayerCollide", true);
            counter++;
        }

        if (counter >= numberOfStars)
        {
            finalStar.SetActive(true);
        }

        if (other.GetComponent<FinalStar>())
        {
            animator = other.GetComponent<Animator>();
            animator.SetBool("PlayerCollideFinal", true);
            levelBounds.SetActive(false);
            animator = platform.GetComponent<Animator>();
            animator.SetTrigger("PlatformFall");
            //SceneManager.LoadScene(5); //transitionscene
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
        

  
