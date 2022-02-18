using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpThings : MonoBehaviour
{
    [SerializeField] Transform Equip;
    [SerializeField] float distance = 5f;

    GameObject currentWeapon;
    GameObject wp;

    bool CanGrab; 

    // Update is called once per frame
    void Update()
    {
        weapons();

        if (CanGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentWeapon != null)
                    Drop();
                    pick();
            }
        }

        if (currentWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                Drop();
        }
    }

    void weapons()
    {
        if(transform.tag == "CanGrab")
        {
            CanGrab = true; 
        }
    }

    void pick()
    {
        currentWeapon = wp;
        currentWeapon.transform.position = Equip.position;
        currentWeapon.transform.parent = Equip;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon = null;
    }
}
