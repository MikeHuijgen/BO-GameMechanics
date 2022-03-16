using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy settings")]
    [SerializeField] int enemyHealth = 20;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bulletP")
        {
            enemyHealth--;

            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
