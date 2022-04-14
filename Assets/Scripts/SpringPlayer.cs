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

    [Header("smokeJump")]
    [SerializeField] ParticleSystem landDust;
    [SerializeField] ParticleSystem jumpWalkRunDust;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        CheckGround();
        if (Input.GetKey(KeyCode.Space) && isJumped)
        {
            if (isJumped)
            {
                isJumped = false;
                rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse); 
                JumpDust();
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

    void LandDust()
    {
        landDust.Play();
    }

    void JumpDust()
    {
        jumpWalkRunDust.Play();
    }
}

/*void FixedUpdate()
   {
       RaycastHit hit;

       isGrounded = true;
       Debug.Log(isGrounded);

       if (Physics.Raycast(transform.position, -transform.up, out hit, 2)) 
       {
           if (Input.GetKey(KeyCode.Space) && isGrounded)
           {
               isGrounded = true;
               rb.AddForce(Vector3.up * jumpForce);              
               jumpSmoke();
           }
       }
       else
       {
           landSmoke();
           isGrounded = false;
           Debug.Log(isGrounded);

       }        
   }*/