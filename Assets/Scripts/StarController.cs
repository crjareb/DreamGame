using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class StarController : MonoBehaviour
{
    public int counter; 
    public Sprite[] starSprites;
    public Sprite explosion;
    public WaitForSeconds switchTime; 

    public void OnTriggerEnter2D(Collider2D other)
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
    }
}
        

  
