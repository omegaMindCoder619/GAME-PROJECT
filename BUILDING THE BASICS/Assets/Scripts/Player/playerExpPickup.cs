using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerExpPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
