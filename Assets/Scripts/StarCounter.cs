using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class StarController : MonoBehaviour
{
    public int counter;
    private Animator animator;
    //public Sprite[] starSprites;
    //public Sprite explosion;
    //public WaitForSeconds switchTime; 

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Star>() != null)
        {
            counter++;
            animator = other.GetComponent<Animator>();
            animator.SetBool("PlayerCollide", true);
        }
    }


    /*public void OnTriggerEnter2D(Collider2D other)
    {
        Sprite currSprite = starSprites[counter];
        if (counter< starSprites.Length)
        {
            counter++; 
        }
        else
        {
            Destroy(transform.gameObject);
            counter = 0;
        }


        yield return new WaitForSeconds(switchTime);
        StartCoroutine("SwitchSprite");

        Instantiate(explosion, transform.position, transform.rotation);
    }*/
}
        

  
