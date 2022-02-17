using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    [SerializeField] Transform equipPosition;
    [SerializeField] float distance = 10f;
    GameObject currentweapon;
    GameObject wp;

    bool CanGrab;

    void Update()
    {
        Weapons();

        if (CanGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentweapon != null)  
                Drop();
                PickUp();
            }
        }

        if (currentweapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                Drop();
        }
    }

    void Weapons()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "CanGrab")
            {
                Debug.Log("I've got the weapon!!");
                CanGrab = true;
                wp = hit.transform.gameObject;
            }
        }
        else
        {
            CanGrab = false;
        }


    }
    void PickUp()
    {
        currentweapon = wp;
        currentweapon.transform.position = equipPosition.position;
        currentweapon.transform.parent = equipPosition;
        currentweapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        currentweapon.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Drop()
    {
        currentweapon.transform.parent = null;
        currentweapon.GetComponent<Rigidbody>().isKinematic = false;
        currentweapon = null;
    }
}
