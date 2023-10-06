using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logScript : MonoBehaviour
{
    public GameObject breakPrefab;
    private AudioSource breakingNoise; 
    // Start is called before the first frame update
    void Start()
    {
        breakingNoise = GetComponent<AudioSource>(); 
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        breakingNoise.Play();
        Explode();

    }
    public void Explode()
    {
        Destroy(transform.gameObject);
        Instantiate(breakPrefab, transform.position, Quaternion.identity);

    }
}

