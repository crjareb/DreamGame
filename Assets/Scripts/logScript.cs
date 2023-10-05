using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logScript : MonoBehaviour
{
    public GameObject breakPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if Alice collides with game object
        //destroy this object
        //call the log break script


        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Explode();

    }
    void Explode()
    {
        Destroy(transform.gameObject);
        Instantiate(breakPrefab, transform.position, Quaternion.identity);

    }
}

