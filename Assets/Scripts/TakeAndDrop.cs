using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAndDrop : MonoBehaviour
{
    public float drop = 2f; 

    public void Commence (float amount)
    {
        drop -= amount;
        if (drop <= 0f)
        {
            Go();
        }
    }

    void Go()
    {
        Destroy(gameObject); 
    }
}
