using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class slimeController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) // will restart level when collide with box collider
    {
        //PlatformerController2D controller = other.gameObject.GetComponent<PlatformerController2D>();
        //if (controller != null)

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
