using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;

    public GameObject mainCam;
    public GameObject ShootCam;
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
            ShootCam.SetActive(true);
            cinaShoot.SetActive(true);
            cinaMain.SetActive(false);
            mainCam.SetActive(false);
        }
        else
        {
            mainCam.SetActive(true);
            cinaMain.SetActive(true);
            ShootCam.SetActive(false);
            cinaShoot.SetActive(false);
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(ShootCam.transform.position, ShootCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
