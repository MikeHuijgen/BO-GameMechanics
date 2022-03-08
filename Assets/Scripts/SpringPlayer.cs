using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlayer : MonoBehaviour
{
    Rigidbody rb;

    [Header("Jump")]
    [SerializeField] float jumpForce = 0f;
    public bool isGrounded;
    private Vector3 jump;
    
    [Header("smokeJump")]
    [SerializeField] ParticleSystem landDust;
    [SerializeField] ParticleSystem jumpWalkRunDust;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.0f, 0.0f);
    }

    void OnCollisionEnter()
    {
        landSmoke();
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce (jump * jumpForce, ForceMode.Impulse);
            jumpSmoke();
            isGrounded = false; 
        }   
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
