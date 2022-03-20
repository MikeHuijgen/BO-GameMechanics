using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAndDrop : MonoBehaviour
{
    [Header("Layers")]
    [SerializeField] private LayerMask PickupLayer;

    [Header("Camera's")]
    [SerializeField] private Camera PlayerCamera;

    [Header("Floats")]
    [SerializeField] private float ThrowingForce;
    [SerializeField] private float PickupRange;

    [Header("Transforms")]
    [SerializeField] private Transform Hand;

    private Rigidbody CurrentObjectRigidbody; //Move it around and have the object in hand.
    private Collider CurrentObjectCollider;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray Pickupray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);

            if (Physics.Raycast(Pickupray, out RaycastHit hitInfo, PickupRange, PickupLayer))
            {
                if (CurrentObjectRigidbody)
                {
                    //Calculated in the physics loop
                    CurrentObjectRigidbody.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    //Replace it with a new object
                    CurrentObjectRigidbody = hitInfo.rigidbody;
                    CurrentObjectCollider = hitInfo.collider;

                    //Then the object becomes Kinematic
                    CurrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                }
                else // if we don't have an Item in the hand
                {
                    CurrentObjectRigidbody = hitInfo.rigidbody;
                    CurrentObjectCollider = hitInfo.collider;

                    CurrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                }

                return; //if you do hit a object.
            }

            if (CurrentObjectRigidbody)//Reset your object
            {
                CurrentObjectRigidbody.isKinematic = false;
                CurrentObjectCollider.enabled = true;

                CurrentObjectRigidbody = null;
                CurrentObjectCollider = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (CurrentObjectRigidbody)
            {
                CurrentObjectRigidbody.isKinematic = false;
                CurrentObjectCollider.enabled = true;

                CurrentObjectRigidbody.AddForce(PlayerCamera.transform.forward * ThrowingForce, ForceMode.Impulse); // You can throw the object with a force behind it.

                CurrentObjectRigidbody = null;
                CurrentObjectCollider = null;
            }
        }

        if (CurrentObjectRigidbody)
        {
            CurrentObjectRigidbody.position = Hand.position; //If the object is in the hand where is it.
            CurrentObjectRigidbody.rotation = Hand.rotation; //If the object is in the hand how is it rotated.
        }
    }
}
