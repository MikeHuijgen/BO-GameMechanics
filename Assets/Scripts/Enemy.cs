using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform player;

    [Header("Enemy settings")]
    [SerializeField] int maxHealth = 20;
    [SerializeField] int currentHealth;

    [Header("UI references")]
    [SerializeField] HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        death();
        LookAtPlayer();
    }

    public void TakeDamage(int bulletdamage)
    {
        currentHealth -= bulletdamage;
        healthBar.SetHealth(currentHealth);
    }

    void LookAtPlayer()
    {
        transform.LookAt(player);
    }

    void death()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            currentHealth = 0;
        }
    }

}
