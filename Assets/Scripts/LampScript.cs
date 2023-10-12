using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lamp : MonoBehaviour
{

    Animator animator;
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7) //if final scene - turn lamp on
        {
            Invoke("LampOn", 1f);
        }
    }

    public void LampOn()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("LampOn");
    }
    public void DestroyLamp()
    {
        Destroy(gameObject);
    }
}
