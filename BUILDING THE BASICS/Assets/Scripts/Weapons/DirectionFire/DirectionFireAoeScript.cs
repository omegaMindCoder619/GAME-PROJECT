using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionFireAoeScript : MonoBehaviour
{
    public int aoeDmg = 100;
    // Start is called before the first frame update
    void Awake()
    {
        Invoke("DestroySelf", 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        EnemyStats enemy = collisionInfo.GetComponent<EnemyStats>();
        if (enemy != null)
        {
            enemy.TakeDamage(aoeDmg);
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}


