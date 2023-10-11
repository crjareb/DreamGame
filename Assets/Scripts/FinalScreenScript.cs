using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScreenScript : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
