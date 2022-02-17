using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRunPlayer : MonoBehaviour
{
    [Header("Movement aanpassingen")]
    [SerializeField] float speed = 10f;
    [SerializeField] float cameraSensX = 1f;
    [SerializeField] Camera playerEyes;


    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Walk();
        Run();

        transform.Rotate(0, mouseX * cameraSensX * Time.deltaTime, 0);
    }

    void Walk()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20f;
        }
        else
        {
            speed = 10f;
        }
    }
}
