using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlayer : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] float distToGround = 1.3f;
    Rigidbody rb;

    [Header("All BOOLS")]
    public bool isJumped;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        CheckGround();
        if (Input.GetKey(KeyCode.Space) && isJumped)
        {
            if (isJumped)
            {
                AnimationJump();
                isJumped = false;
                rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);              
            }
        }
    }
    private void CheckGround()
    {
        RaycastHit hit;

        Ray landingRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * distToGround);

        if (Physics.Raycast(landingRay, out hit, distToGround))
        {
            if (hit.collider == null)
            {
                isJumped = false;
                Debug.Log(isJumped);
            }
            else
            {
                isJumped = true;
                Debug.Log(isJumped);
            }
        }
    }

    void AnimationJump()
    {
        animator.CrossFade("Jump", 0.5f);
    }
}