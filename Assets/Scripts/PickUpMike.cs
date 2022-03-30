using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpMike : MonoBehaviour
{
    [SerializeField] LayerMask pickUp;
    [SerializeField] Transform handRaySpawn;
    [SerializeField] Transform rayDestination;
    [SerializeField] TMP_Text pickUpText;


    Ray ray;
    RaycastHit hitInfo;

    [SerializeField] bool isPickedUp;

    Transform myPickUp;
    Rigidbody pickUpRB;
    BoxCollider pickUpCollider;

    private float throwForceZ = 15f;
    private float throwForceY = 5f;

    void Start()
    {
        isPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPickUp();
        Drop();
    }

    void CheckPickUp()
    {
        ray.origin = handRaySpawn.position;
        ray.direction = rayDestination.position - handRaySpawn.position;

        if (Physics.Raycast(ray, out hitInfo, 100f, pickUp))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            pickUpText.enabled = true;
            myPickUp = hitInfo.transform;
            PickUp();
        }
        else
        {
            pickUpText.enabled = false;
        }
    }

    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPickedUp == false)
        {
            pickUpText.enabled = false;

            //set the semiGun script on if you pick up de gun
            SemiGun semiGun = myPickUp.transform.GetComponent<SemiGun>();
            semiGun.ActivateGun(true);
            
            pickUpRB = myPickUp.GetComponent<Rigidbody>();
            pickUpCollider = myPickUp.GetComponent<BoxCollider>();

            //set the rigidbody and the collider on the item you picked up on false
            pickUpRB.useGravity = false;
            pickUpCollider.enabled = false;

            myPickUp.transform.parent = handRaySpawn.transform;
            myPickUp.rotation = handRaySpawn.rotation;
            myPickUp.position = handRaySpawn.position;

            isPickedUp = true;
        }
    }

    void Drop()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isPickedUp == true)
        {
            //set the semiGun script off if you drop de gun
            SemiGun semigun = myPickUp.GetComponent<SemiGun>();
            semigun.ActivateGun(false);

            //set the rigidbody and the collider on the item you drop true
            pickUpRB.useGravity = true;
            pickUpCollider.enabled = true;

            handRaySpawn.transform.DetachChildren();
            isPickedUp = false;
            pickUpRB.AddRelativeForce(0,throwForceY,throwForceZ, ForceMode.Impulse);
            pickUpRB.AddTorque(0, throwForceY, throwForceZ);
            
            Debug.Log("je hebt het neer gegooid");
            
        }
    }

}
