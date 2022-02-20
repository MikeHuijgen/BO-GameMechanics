using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [SerializeField] Rigidbody BulletPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float bulletVelocity = 200f;
    [SerializeField] float aimYSens = 10f;
    [SerializeField] float maxY = 90;
    [SerializeField] float minY = -90;
    [SerializeField] Transform pistol;

    public GameObject mainCam;
    public GameObject cinaMain;
    public GameObject cinaShoot;

    float mouseY;
    float yRotation;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetButton("Fire2"))
        {
            cinaShoot.SetActive(true);
            cinaMain.SetActive(false);

            RotateGun();

        }
        else
        {
            cinaMain.SetActive(true);
            cinaShoot.SetActive(false);
        }
    }

    void Shoot()
    {
        Rigidbody clone;
        clone = (Rigidbody)Instantiate(BulletPrefab, spawnPoint.position, BulletPrefab.rotation);

        clone.velocity = spawnPoint.TransformDirection(Vector3.forward * bulletVelocity);
    }

    void RotateGun()
    {
        mouseY += Input.GetAxis("Mouse Y") * Time.deltaTime;

        yRotation = Mathf.Clamp(mouseY, 0, -30);

        transform.localRotation = Quaternion.Euler(yRotation , 0, 0);

        //transform.Rotate(yRotation * aimYSens * Time.deltaTime ,0 ,0);
        
    }
}

