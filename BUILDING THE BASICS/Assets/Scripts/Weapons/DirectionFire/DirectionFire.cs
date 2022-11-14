using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float startDelay = 0.1f;
    public float shootInterval = 0.5f;
    public float bulletInterval = 0.1f;
    public int gunLevel = 4;
    public Vector2 direction;




    void Start()
    {
        direction = new Vector2(1f, 0f);
        InvokeRepeating("Shoot", startDelay, shootInterval);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("s"))
        {
            Debug.Log(direction + "s");
            direction = new Vector2(0, -1);
        }
        if (Input.GetKey("a"))
        {
            Debug.Log(direction + "a");
            direction = new Vector2(-1, 0);
        }
        if (Input.GetKey("w"))
        {
            Debug.Log(direction + "w");
            direction = new Vector2(0, 1);
        }
        if (Input.GetKey("d"))
        {
            Debug.Log(direction + "d");
            direction = new Vector2(1, 0);
        }
        if (Input.GetKey("w") && Input.GetKey("a"))
        {
            Debug.Log(direction + "wa");
            direction = new Vector2(-0.71f, 0.71f);
        }
        if (Input.GetKey("w") && Input.GetKey("d"))
        {
            Debug.Log(direction + "wd");
            direction = new Vector2(0.71f, 0.71f);
        }
        if (Input.GetKey("a") && Input.GetKey("s"))
        {
            Debug.Log(direction + "as");
            direction = new Vector2(-0.71f, -0.71f);
        }
        if (Input.GetKey("d") && Input.GetKey("s"))
        {
            Debug.Log(direction + "ds");
            direction = new Vector2(0.71f, -0.71f);
        }

    }

    private void Shoot()
    {
        StartCoroutine(SpawnBullets());
    }


    private IEnumerator SpawnBullets()
    {
        for (int i = 0; i < gunLevel; i++)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(bulletInterval);
        }
    }
}
