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

    [Header("Gun sound")]
    [SerializeField] AudioClip shooting;
    [SerializeField] AudioClip reloading;
    [SerializeField] AudioClip empty;

    [Header("Camera references")]
    [SerializeField] GameObject cinaMain;
    [SerializeField] GameObject cinaShoot;

    [Header("Text references")]
    [SerializeField] TMP_Text AmmoText;

    private float nextTimeFire = 0f;
    private int ammoLeft;
    private int maxAmmoClip;
    AudioSource audioSource;
    private int addAmmo = 10;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeFire)
        {
            nextTimeFire = Time.time + 1f/fireRate;

            if(magAmmo > 0)
            {
                audioSource.PlayOneShot(shooting);
                Rigidbody clone;
                clone = (Rigidbody)Instantiate(BulletPrefab, spawnPoint.position, BulletPrefab.rotation);

                clone.velocity = spawnPoint.TransformDirection(Vector3.forward * bulletVelocity);
                magAmmo -= 1;
            }
        } 
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            //dev key voor ammo er bij te krijgen
            stockAmmo += addAmmo;
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
        if (Input.GetKeyDown(KeyCode.R) && magAmmo < 7)
        {
            yield return new WaitForSeconds(reloadAmmoSpeed);

            if ( stockAmmo >= maxAmmoClip - magAmmo)
            {
                audioSource.PlayOneShot(reloading);
                ammoLeft = maxAmmoClip - magAmmo;
                magAmmo = magAmmo + ammoLeft;
                stockAmmo -= ammoLeft;
            }
            else if (stockAmmo == 0)
            {
                audioSource.PlayOneShot(empty);
            }
            else
            {
                audioSource.PlayOneShot(reloading);
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

