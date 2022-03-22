using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform player;

    [Header("Enemy settings")]
    [SerializeField] int health = 20;

    [Header("Text references")]
    [SerializeField] TMP_Text enemyHealth;


    // Update is called once per frame
    void Update()
    {
        death();
        LookAtPlayer();
        enemyHealth.text = $"EnemyHealth/{ health }";
    }

    public void TakeDamage(int bulletdamage)
    {
        health -= bulletdamage;
    }

    void LookAtPlayer()
    {
        transform.LookAt(player);
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
