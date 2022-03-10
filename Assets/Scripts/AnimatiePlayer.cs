using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatiePlayer : MonoBehaviour
{
    [SerializeField] private GameObject LowPolyChar;

    void Update()
    { 
        if (Input.GetButtonDown("2Key"))
        {
            LowPolyChar.GetComponent<Animator>().Play("Walk"); 
        }

        if (Input.GetButtonDown("3Key"))
        {
            LowPolyChar.GetComponent<Animator>().Play("Jump"); 
        }
    }
}
