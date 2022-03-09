using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRunPlayer : MonoBehaviour
{
    [Header("Movement aanpassingen")]
    [SerializeField] [Tooltip("With this you can change the players walk speed")] public float walkSpeed = 10f;
    [Header("Camera aanpassingen")]
    [SerializeField] [Tooltip("With this you can change the camera sensitivity")] float cameraSen = 700f;

    private Animation animator;
    private bool isWalking = false;

    float horizontal;
    float vertical;

    void Start()
    {
        animator = GetComponent<Animation>();
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

    }
}
