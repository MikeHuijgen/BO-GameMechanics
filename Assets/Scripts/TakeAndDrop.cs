using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAndDrop : MonoBehaviour
{
    [Header("Layers")]
    [SerializeField] private LayerMask PickupLayer;

    [Header("Floats")]
    [SerializeField] private float ThrowingForce = 8f;
    [SerializeField] private float PickupRange = 6f;

    [Header("Transforms")]
    [SerializeField] private Transform Hand;

    [Header("GameObjects")]
    [SerializeField] private GameObject item;

    [Header("Bools")]
    [SerializeField] private bool Carring;

    Rigidbody rb;

    void Update()
    {
        if (Carring == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickup();
                rb = item.GetComponent<Rigidbody>();
            }
        }
        else if (Carring == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                drop();
              
            }
        }
    }
    void pickup()
    {
        Carring = true; 
        Debug.Log("Heb het in mijn hand");
        item.transform.parent = Hand.transform;
        item.transform.position = Hand.transform.position;
        item.transform.rotation = Hand.transform.rotation;
        rb.useGravity = false; 
    }
    void drop()
    {
        Carring = false; 
        Debug.Log("Laat het vallen");
        item.transform.DetachChildren();
        item.transform.position = Hand.transform.position;     
        rb.AddForce(0, 0, ThrowingForce, ForceMode.Impulse);
        rb.useGravity = true; 
    }
}

