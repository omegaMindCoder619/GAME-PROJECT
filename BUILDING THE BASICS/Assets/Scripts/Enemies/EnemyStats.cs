using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyMaxHp = 100;
    public int enemyCurrentHp;
    public GameObject exp;
    void Start()
    {
        enemyCurrentHp = enemyMaxHp;
    }

    public void TakeDamage (int damage)
    {
        enemyCurrentHp -= damage;
        if (enemyCurrentHp <= 0)
        {
            Death();
        }
    }

    public void Death ()
    {
        Destroy(gameObject);
        Instantiate(exp, transform.position, Quaternion.identity);
    }
}
