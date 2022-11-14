using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionFireTrajectory : MonoBehaviour
{
    public Rigidbody2D bulletRB;
    public GameObject AoePrefab;
    public float bulletSpeed3 = 1.5f;
    public int bulletDamage3 = 50;
    private int piercingCounter = 0;
    private int piercingMax = 3;
    private DirectionFire df;
    Vector2 direction;

    


    void Awake()
    {
        df = GameObject.Find("Player").GetComponent<DirectionFire>();
        direction = df.direction;
        direction.Normalize();
        Invoke("DestroySelf", 1.3f);


    }

    void FixedUpdate()
    {
        bulletRB.velocity = direction * bulletSpeed3 * 5;
        if (piercingCounter >= piercingMax){ DestroySelf(); }
    }


    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        EnemyStats enemy = collisionInfo.GetComponent<EnemyStats>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage3);
            piercingCounter++;
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
        Instantiate(AoePrefab, transform.position, transform.rotation);
    }
}
