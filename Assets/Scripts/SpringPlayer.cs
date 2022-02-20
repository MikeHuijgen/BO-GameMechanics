using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlayer : MonoBehaviour
{

    [Header("Jump")]
    [SerializeField] float jumpForce = 0f;
    public bool isGrounded;
    private Vector3 jump;
    Rigidbody rb;

    [Header("smokeJump")]
    [SerializeField] GameObject particalSmoke;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.0f, 0.0f);
    }

    void OnCollisionEnter()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            Smoke(); 
            isGrounded = false;
        }
    }

    void Smoke()
    {
        
    }
}
