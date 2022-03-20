using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [Header("Enemy settings")]
    [SerializeField] int health = 20;

    [SerializeField] TMP_Text enemyHealth;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        death();
        enemyHealth.text = $"EnemyHealth/{ health }";
    }

    public void TakeDamage(int bulletdamage)
    {
        health -= bulletdamage;
    }

    void death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            health = 0;
        }
    }

}
