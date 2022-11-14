using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    EnemyRadar enemyRadar;

    public float startDelay = 0.1f;
    public float shootInterval = 0.5f;
    public float bulletInterval = 0.1f;
    public int gunLevel = 1;

    
    void Start()
    {
        enemyRadar = GameObject.Find("EnemyRadar").GetComponent<EnemyRadar>();

        InvokeRepeating("Shoot", startDelay, shootInterval);

    }
    
    private void Shoot()
    {
        if (enemyRadar.enemyInRadar == true && enemyRadar.closestEnemy != null)
        {
            StartCoroutine(SpawnBullets());
        }
    }


    private IEnumerator SpawnBullets ()
    {
        for (int i = 0; i < gunLevel; i++)
        {
            if (enemyRadar.enemyInRadar == true && enemyRadar.closestEnemy != null)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                yield return new WaitForSeconds(bulletInterval);
            }
   
        }
    }
}
