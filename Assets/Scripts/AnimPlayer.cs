using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{

    GameObject animation;

    private void Update()
    {
        if (Input.GetAxis("Vertical") > 0.2)
        {
            animation.GetComponent<Animator>().Play("0 - 60"); 
        }
        else
        {
            animation.GetComponent<Animator>().Play(80 - 120);
        }
    }
}
