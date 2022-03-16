using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy settings")]
    [SerializeField] int enemyHealth = 20;

    [Header("Bullet Damage")]
    [SerializeField] int pistolBullet = 10;
    [SerializeField] int arBullet = 4;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "bulletP")
        {
            enemyHealth -= pistolBullet;
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
