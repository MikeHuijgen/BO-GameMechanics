using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAir : MonoBehaviour
{
    public Transform mainCamera;

    Ray ray;
    RaycastHit hitInfo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = mainCamera.position;
        ray.direction = mainCamera.forward;

        if (Physics.Raycast(ray, out hitInfo))
        {
            transform.position = hitInfo.point;
        }
 
    }
}
