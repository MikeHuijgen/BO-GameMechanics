using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovementPlayer : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] float cameraSenX;
    [SerializeField] float cameraSenY;
    [Header("Transform References")]
    [SerializeField] Transform followTransform;
    [SerializeField] Transform guns;


    void Update()
    {
        CameraRotation();
        GunRotation();
    }

    void CameraRotation()
    {
        //Get input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        //Rotate the follow transform based on input
        followTransform.transform.rotation *= Quaternion.AngleAxis(mouseX * cameraSenX * Time.deltaTime, Vector3.up);
        followTransform.transform.rotation *= Quaternion.AngleAxis(mouseY * cameraSenY * Time.deltaTime, Vector3.right);

        //Clamping looking Up/Down 
        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;

        var angle = followTransform.transform.localEulerAngles.x;

        if (angle > 180 && angle < 330)
        {
            angles.x = 330;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        followTransform.transform.localEulerAngles = angles;

        //Rotate player with camera
        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
        //Reste the y rotation of look transform
        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
    }

    void GunRotation()
    {
        float mouseY = -Input.GetAxis("Mouse Y");

        guns.transform.rotation *= Quaternion.AngleAxis(mouseY * cameraSenY * Time.deltaTime, Vector3.right);

        var angles = guns.transform.localEulerAngles;
        angles.z = 0;

        var angle = guns.transform.localEulerAngles.x;

        if (angle > 180 && angle < 330)
        {
            angles.x = 330;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        guns.transform.localEulerAngles = angles;

    }
}