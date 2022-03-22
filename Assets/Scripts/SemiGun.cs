using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SemiGun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform raycastSpawn;
    [SerializeField] Transform raycastDestination;
    [SerializeField] TrailRenderer tracerEffect;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Rigidbody rbPlayer;
    [SerializeField] Transform hand;

    [Header("Gun settings")]
    [SerializeField] int damage = 1;
    [SerializeField] float fireRate = 10f;
    [SerializeField] int magAmmo = 7;
    [SerializeField] int stockAmmo = 30;
    [SerializeField] float rangeShooting = 100f;
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
    private int addAmmo = 10;
    
    AudioSource audioSource;


    RaycastHit hitInfo;
    Ray ray;



    void Start()
    {
        transform.GetComponent<SemiGun>().enabled = false;
        audioSource = GetComponent<AudioSource>();
        maxAmmoClip = magAmmo;
    }

    void Update()
    {
        Shoot();
        Aim();
        StartCoroutine(Reload());
        AmmoCountScreen();

        //dev keys voor allemaal dingen verwijderen voor het inleveren
        if (Input.GetKeyDown(KeyCode.M))
        {
            //dev key voor ammo er bij te krijgen
            stockAmmo += addAmmo;
        }

    }

    public void ActivateGun(bool active)
    {
        if (active == true)
        {
            transform.GetComponent<SemiGun>().enabled = true;
            AmmoText.enabled = true;
        }
        else
        {
            transform.GetComponent<SemiGun>().enabled = false;
            AmmoText.enabled = false;
        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeFire)
        {
            nextTimeFire = Time.time + 1f/fireRate;

            if(magAmmo > 0)
            { 
                audioSource.PlayOneShot(shooting);
                magAmmo--;
                Instantiate(hitEffect, raycastSpawn.transform.position, Quaternion.Euler(Vector3.forward));

                ray.origin = raycastSpawn.position;
                ray.direction = raycastDestination.position - raycastSpawn.position;

                var tracer = Instantiate(tracerEffect,ray.origin, Quaternion.identity);
                tracer.AddPosition(ray.origin);

                if (Physics.Raycast(ray, out hitInfo))
                {      
                    Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
                    Debug.Log(hitInfo.transform.name);

                    //Spawn a hitEffect when you hit something
                    Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

                    tracer.transform.position = hitInfo.point;


                    Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(damage);
                    }
                }
            }
            else if(magAmmo <= 0 && stockAmmo <= 0)
            {
                audioSource.PlayOneShot(empty);
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
        if (Input.GetKeyDown(KeyCode.R) && magAmmo < maxAmmoClip)
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
