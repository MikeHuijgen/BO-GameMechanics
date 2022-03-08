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
    public bool isGrounded; 

    [Header("smokeJump")]
    [SerializeField] ParticleSystem landDust;
    [SerializeField] ParticleSystem jumpWalkRunDust;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log(Ground());

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(0, jumpSpeed, 0);
            isGrounded = false; 
        }
        else
        {
            isGrounded = true; 
        }
    }

    bool Ground()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }

    void landSmoke()
    {
        landDust.Play();
    }

    void jumpSmoke()
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