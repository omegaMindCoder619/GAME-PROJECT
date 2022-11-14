using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFireTrajectory : MonoBehaviour
{
    public Rigidbody2D bulletRB;
    public float bulletSpeed1 = 1.5f;
    public int bulletDamage1 = 50;
    private CircleFire cf;
    Vector2 direction;


    void Awake()
    {
        cf = GameObject.Find("Player").GetComponent<CircleFire>();
        direction = cf.direction;
        direction.Normalize();
        Invoke("DestroySelf", 1.5f);

 
    }

    void FixedUpdate()
    {
        bulletRB.velocity = direction * bulletSpeed1 * 5;
    }


    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        EnemyStats enemy = collisionInfo.GetComponent<EnemyStats>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage1);
            Destroy(gameObject);
        }
    }


    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
