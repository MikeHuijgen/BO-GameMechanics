using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRunPlayer : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] [Tooltip("You can change the walk speed with this variable")] public float walkSpeed = 10f;

    private Animator animator;
    private bool isWalking = false;

    float horizontal;
    float vertical;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();

    }


    void Walk()
    {
        //Move Player
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * vertical * walkSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontal * walkSpeed * Time.deltaTime);

        animator.SetBool("isWalking", true);
        
    }
}
