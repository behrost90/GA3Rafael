using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;  

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;           // another way of writing this is currentHealth = currentHealth - damage     and also the order of -= is important

        if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    private void Die()
    {
        Debug.Log("player died");   
    }
}
