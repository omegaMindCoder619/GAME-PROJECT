using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    private GameObject[] onScreenEnemies;
    public Transform closestEnemy = null;
    public bool enemyInRadar = false;
    void Start()
    {
        closestEnemy = null;
    }

    // Update is called once per frame
    void Update()
    {
        closestEnemy = getClosestEnemy();
    }

    public Transform getClosestEnemy()
    {
        onScreenEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (onScreenEnemies.Length > 0)
        {
            float closestDistance = Mathf.Infinity;
            Transform trans = null;

            foreach (GameObject enemy in onScreenEnemies)
            {
                float currentDistance;
                currentDistance = Vector3.Distance(transform.position, enemy.transform.position);

                if (currentDistance < closestDistance)
                {
                    closestDistance = currentDistance;
                    trans = enemy.transform;
                }
            }
            return trans;
        }
        else return null;
    }

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Enemy")
        {
            enemyInRadar = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Enemy")
        {
            enemyInRadar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Enemy")
        {
            enemyInRadar = false;
        }
    }
}
