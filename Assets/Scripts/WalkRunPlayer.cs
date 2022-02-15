using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRunPlayer : MonoBehaviour
{
    float horizontal;
    float vertical;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);

        Run();
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
