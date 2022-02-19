using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpThings : MonoBehaviour
{
    [SerializeField] Transform Equip;
    
    GameObject currentObject;
    GameObject cO;

    bool CanGrab;

    void Update()
    {
        weapons();
        if (CanGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentObject != null)
                    Drop();
                    Pick();
            }
        }

        if (currentObject != null)
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

    void Pick()
    {
        currentObject = cO;
        currentObject.transform.position = Equip.position;
        currentObject.transform.parent = Equip;
        currentObject.transform.localEulerAngles = new Vector3(0f, 180.0f, 0f);
        currentObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Drop()
    {
        currentObject.transform.parent = null;
        currentObject.GetComponent<Rigidbody>().isKinematic = false;
        currentObject = null;
    }
}