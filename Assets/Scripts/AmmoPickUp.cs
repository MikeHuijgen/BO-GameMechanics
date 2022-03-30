using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] public int pickedUpAmmo = 5;


    [SerializeField] Transform gun;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            SemiGun semiGun = gun.transform.GetComponent<SemiGun>();

            semiGun.AddAmmo(pickedUpAmmo);
            Destroy(gameObject);
        }
    }
}
