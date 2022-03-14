using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Guns : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody BulletPrefab;
    [SerializeField] Transform spawnPoint;
    
    [Header("Gun settings")]
    [SerializeField] float bulletVelocity = 200f;
    [SerializeField] float fireRate = 10f;
    [SerializeField] int magAmmo = 7;
    [SerializeField] int stockAmmo = 30;
    [SerializeField] float reloadAmmoSpeed;

    [Header("Camera references")]
    [SerializeField] GameObject cinaMain;
    [SerializeField] GameObject cinaShoot;

    [Header("Text references")]
    [SerializeField] TMP_Text AmmoText;

    private float nextTimeFire = 0f;
    private int ammoLeft;
    private int maxAmmoClip;



    void Start()
    {
        maxAmmoClip = magAmmo;
    }

    void Update()
    {
        Shoot();
        Aim();
        StartCoroutine(Reload());
        AmmoCountScreen();

    }

    void Shoot()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeFire)
        {
            nextTimeFire = Time.time + 1f/fireRate;

            if(magAmmo > 0)
            {
                Rigidbody clone;
                clone = (Rigidbody)Instantiate(BulletPrefab, spawnPoint.position, BulletPrefab.rotation);

                clone.velocity = spawnPoint.TransformDirection(Vector3.forward * bulletVelocity);
                magAmmo -= 1;
            }
        }     
    }

    void Aim()
    {
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

    IEnumerator Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            yield return new WaitForSeconds(reloadAmmoSpeed);

            if ( stockAmmo >= maxAmmoClip - magAmmo)
            {
                ammoLeft = maxAmmoClip - magAmmo;
                magAmmo = magAmmo + ammoLeft;
                stockAmmo -= ammoLeft;
            }
            else
            {
                magAmmo += stockAmmo;
                stockAmmo = 0;
            }
        }
    }

    void AmmoCountScreen()
    {
        AmmoText.text = $"{magAmmo}/{stockAmmo}";
    }
}

