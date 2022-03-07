using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [SerializeField] Rigidbody BulletPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float bulletVelocity = 200f;
    [SerializeField] Transform pistol;

    public GameObject mainCam;
    public GameObject cinaMain;
    public GameObject cinaShoot;

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
}

