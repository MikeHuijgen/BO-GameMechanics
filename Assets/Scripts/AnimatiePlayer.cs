using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatiePlayer : MonoBehaviour
{
    private Animator animator;
    private bool isJumping = false;


    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }
    private void Update()
    {
        animator.SetBool("isJumping", true); 
    }
}
