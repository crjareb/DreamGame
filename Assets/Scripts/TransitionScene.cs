using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TransitionScene : MonoBehaviour
{

    public static TransitionScene instance;
    private Animator animator;
    public GameObject levelBounds;
    public GameObject platform;
    public TextMeshProUGUI starCountText;
    private int totalStarCount = 15;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        starCountText.text = string.Empty;
    }
    public void Transition()
    {
        levelBounds.SetActive(false);                   //player can fall
        animator = platform.GetComponent<Animator>();   //platform falls
        animator.SetTrigger("PlatformFall");
        animator = gameObject.GetComponent<Animator>(); //fade to black
        animator.SetTrigger("StartTransition");
    }

    private void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }


    private void ShowStarCount()
    {;
        if (SceneManager.GetActiveScene().buildIndex == 1) //if tutorial scene only 3 stars
        {
            totalStarCount = 3;
        }
        else
        {
            totalStarCount = 15;
        }
        starCountText.text = StarCounter.counter + "/" + totalStarCount;
    }
}
