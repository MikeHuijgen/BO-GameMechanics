using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpThings : MonoBehaviour
{
    [Header("Objecten")]
    [SerializeField] GameObject EquipObject;
    
    GameObject currentObject;
    GameObject cO;

    bool hasItem;
    

    private void Start()
    {
        
        hasItem = false; 
    }


    void Update()
    {
        if (hasItem == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentObject != null)
                    Drop();
                    Pick();

            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (currentObject != null)
                    Drop();
            }
        }
           
    }

    void Pick()
    {
        currentObject = cO;
        currentObject.GetComponent<Rigidbody>().isKinematic = true;
        currentObject.transform.position = EquipObject.transform.position;
        currentObject.transform.parent = null;
        currentObject.transform.localEulerAngles = new Vector3(0f, 180.0f, 0f);
    }

    void Drop()
    {
        currentObject.transform.parent = null;
        currentObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hasItem")
        {
            hasItem = true;
            currentObject = other.gameObject; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        hasItem = false; 
    }
}