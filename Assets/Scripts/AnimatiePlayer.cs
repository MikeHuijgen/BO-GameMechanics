using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatiePlayer : MonoBehaviour
{
    [SerializeField] private GameObject thePlayer;
    private Animation animator;
    bool isWalking = false;
   

    private void Start()
    {
        animator = GetComponent<Animation>(); 
    }


    void Update()
    {
        if (Input.GetButtonDown("1Key"))
        {
            thePlayer.GetComponent<Animator>().Play("Walk");
            isWalking = true; 
        }

        if (Input.GetButtonDown("2Key"))
        {
            thePlayer.GetComponent<Animator>().Play("Walk");
        }

        if (Input.GetButtonDown("3Key"))
        {
            thePlayer.GetComponent<Animator>().Play("Jump");
        }
    }
}
