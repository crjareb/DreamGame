using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Animator animator;
    public GameObject title;
    void Start()
    {

    }
    public void OnMouseDown()
    {
        animator.SetBool("LampOff", true);
        Invoke("Title", 1f);
        Invoke("ChangeScene", 1f);

    }
    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

    void Title()
    {
        title.GetComponent<SpriteRenderer>().enabled = true;
    }
}
