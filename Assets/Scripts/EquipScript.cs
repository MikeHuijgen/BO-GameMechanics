using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Gun;
    public Camera Camera;
    public float range = 2f;
    public float open = 100f;

    // Start is called before the first frame update
    void Start()
    {

        //Zodat de gun wel gewicht heeft maar wil dat hij nergens heen kan doordat hij Kinematic is.
        Gun.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

        //Als je op "E" drukt.
        if (Input.GetKeyDown("e"))
        {

            //Worden deze twee codes geactiveerd.
            UnequipObject();
            Shoot();
        }
    }

    void Shoot()
    {
        //Dit zorgt er voor dat er een lijn naar wapen of object word gestuurd en dat je het kan oppakken.
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            TakeAndDrop target = hit.transform.GetComponent<TakeAndDrop>();
            if (target != null)
            {
                EquipObject();
            }
        }
    }

    void UnequipObject()
    {
        PlayerTransform.DetachChildren();

        //Als je het wapen weggooit dat het wapen op z'n zij komt te liggen.
        Gun.transform.eulerAngles = new Vector3(Gun.transform.eulerAngles.x, Gun.transform.eulerAngles.y, Gun.transform.eulerAngles.z - 45);
        Gun.GetComponent<Rigidbody>().isKinematic = false;
    }

    void EquipObject()
    {
        Gun.GetComponent<Rigidbody>().isKinematic = true;
        Gun.transform.position = PlayerTransform.transform.position;
        Gun.transform.rotation = PlayerTransform.transform.rotation;
        Gun.transform.SetParent(PlayerTransform);
    }
}
