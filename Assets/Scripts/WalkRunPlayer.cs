using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRunPlayer : MonoBehaviour
{
    [Header("Movement aanpassingen")]
    [SerializeField] [Tooltip("With this you can change the players walk speed")] public float walkSpeed = 10f;
    [SerializeField] [Tooltip("With this you can change the players run speed")] float runSpeed = 15f;
    [Header("Camera aanpassingen")]
    [SerializeField] [Tooltip("With this you can change the camera sensitivity")] float cameraSen = 700f;

    float horizontal;
    float vertical;

    void Update()
    {
        Walk();
        Run();
    }

    void Walk()
    {
        //Move Player
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * vertical * walkSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontal * walkSpeed * Time.deltaTime);

        //Move player with camera
        //float mouseX = Input.GetAxis("Mouse X");
        //transform.Rotate(0, mouseX * cameraSen * Time.deltaTime, 0);

    }

    void Run()
    {
        //Move player faster while you run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            walkSpeed = runSpeed;
        }
        else
        {
            walkSpeed = 10f;
        }
    }

}
