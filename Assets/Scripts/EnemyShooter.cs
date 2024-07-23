using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootInterval = 2f;
    public float projectileSpeed = 5f;





    void Start()
    {
        StartCoroutine(MyFirstCoroutine());     

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator MyFirstCoroutine()
    {
        while (true)                                 //carefull, if you put it in update, will break the game most of times
        {
            ShootProjectile();
            yield return new WaitForSeconds(shootInterval);
        }

        
       
    }

    private void ShootProjectile()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;

            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        }
       

        
    }



}
