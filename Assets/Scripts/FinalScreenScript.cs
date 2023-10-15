using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScreenScript : MonoBehaviour
{

    private AudioSource backgroundLOne;
    void Start()
    {
        backgroundLOne = GetComponent<AudioSource>();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
