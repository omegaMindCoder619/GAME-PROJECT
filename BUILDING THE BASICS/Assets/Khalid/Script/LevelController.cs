using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int sceneBuildIndex; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player Enter");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Enter next level");
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single); // Only loads one level

        }
    }
}
