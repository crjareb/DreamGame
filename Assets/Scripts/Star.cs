using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public void DestroyStar() 
    { 
        Destroy(gameObject); 
    }

    public void CountIncrease()
    {
        StarCounter.counter++;
    }
}
