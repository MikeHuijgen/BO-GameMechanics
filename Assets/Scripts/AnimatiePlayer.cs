using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatiePlayer : MonoBehaviour
{
    private Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        AnimationPickUp();
    }

    void AnimationPickUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.CrossFade("PickUp", 0.5f);
        }        
    }
}