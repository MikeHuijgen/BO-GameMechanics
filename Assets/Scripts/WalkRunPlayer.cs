using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRunPlayer : MonoBehaviour
{
    [Header("Movement aanpassingen")]
    [SerializeField] float speed = 10f;
    [SerializeField] float playerSens = 700f;


    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
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

        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);

        //Move player with camera
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * playerSens * Time.deltaTime, 0);
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
