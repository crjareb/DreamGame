using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float lifetime;
    public Vector3 direction;
    public GameObject Alice;

    void Start()
    {
        GameObject Alice = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPos = Alice.transform.position;
        direction = playerPos - transform.position;

        direction.Normalize();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;

        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }


    }

    void OnTriggerEnter2D(Collider2D other)

    {

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }
}
