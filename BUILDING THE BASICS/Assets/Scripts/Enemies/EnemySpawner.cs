using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject blackSquare;
    public float startDelay = 2f;
    public float spawnInterval = 4f;
    public int enemyTier = 1;
    public int enemyWaveAmount = 10;
    
    void Start()
    {
        InvokeRepeating("SpawnA", startDelay, spawnInterval);
    }

    public void SpawnEnemy(int tier, int amount)
    {
        float x = 0;
        float y = 0;
        int positiveOrNegative = 0;
        int positiveOrNegative2 = 0;
        for (int i = 0; i < amount; i++)
        {
            x = Random.Range(0, 9);
            y = Mathf.Sqrt(64 - Mathf.Pow(x, 2));

            positiveOrNegative = Random.Range(0, 2);
            positiveOrNegative2 = Random.Range(0, 2);

            if (positiveOrNegative == 1) { x = x * -1; }
            if (positiveOrNegative2 == 1) { y = y * -1; }

            Vector3 spawnLocation = new Vector3(transform.position.x + x, transform.position.y + y, 0);

            Instantiate(blackSquare, spawnLocation, Quaternion.identity);

            //Debug.Log("x: " + x + " y: " + y + " posOrNeg: " + positiveOrNegative +  " posOrNeg2: " + positiveOrNegative2);
        }
    }

    public void SpawnA()
    {
        SpawnEnemy(enemyTier, enemyWaveAmount);
    }
}
