using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class slimeController : MonoBehaviour


{
    public AudioSource slimeSound;

    private void Start()
    {
        slimeSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other) // will restart level when collide with box collider
    {
        
    
        if(other.CompareTag("Player"))
        {
            slimeSound.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
