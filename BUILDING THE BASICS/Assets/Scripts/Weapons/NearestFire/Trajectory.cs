using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public Rigidbody2D bulletRB; 
    public float bulletSpeed = 1.5f;
    public int bulletDamage = 50; 
    EnemyRadar enemyRadar;
    Transform currentTarget = null;
    
    Vector2 direction;
    
    
    void Start()
    {
        enemyRadar = GameObject.Find("EnemyRadar").GetComponent<EnemyRadar>();

        currentTarget = enemyRadar.closestEnemy;

        direction = (Vector2)currentTarget.position - bulletRB.position;
        direction.Normalize();

        Invoke("DestroySelf", 1.5f);
    }

    void FixedUpdate()
    {
        bulletRB.velocity = direction * bulletSpeed * 5;
    }


    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
            EnemyStats enemy = collisionInfo.GetComponent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletDamage);
                Destroy(gameObject);
            }   
    }


    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
