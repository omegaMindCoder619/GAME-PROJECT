using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject circleFireBullet;
    EnemyRadar enemyRadar;

    public float startDelay = 0.1f;
    public float shootInterval = 2f;
    public float angleSum = 0;
    public float angleAdd = 0;
    public Vector2 direction = new Vector2(0,0);

    public int gunLevel = 1;
    public int projectilesAmount = 5;

    void Start()
    {
        enemyRadar = GameObject.Find("EnemyRadar").GetComponent<EnemyRadar>();

        InvokeRepeating("Shoot", startDelay, shootInterval);
    }


    private void Shoot()
    {
        angleAdd = 360 / projectilesAmount;

        if (projectilesAmount == 4) { angleSum = -45; }
        else angleSum = 0;

        for (int i = 0; projectilesAmount > i; i++)
        {
            angleSum += angleAdd;
            direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleSum), Mathf.Sin(Mathf.Deg2Rad * angleSum));
            Instantiate(circleFireBullet, firePoint.position, firePoint.rotation);
        }
    }
}
