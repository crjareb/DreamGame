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
        title.GetComponent<SpriteRenderer>().enabled = true;
        Invoke("ChangeScene", 2f);

    }
    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
