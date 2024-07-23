using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageToPlayer = 10; //added for projectile
    public bool destroyOnCollision = false; //added for projectile

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(5);
            Destroy(collision.gameObject);
            //Destroy(gameObject); (for the collectible we write this instead of damage)

            if (destroyOnCollision) Destroy(gameObject); //added for projectile
            
           
        }

    }
}
