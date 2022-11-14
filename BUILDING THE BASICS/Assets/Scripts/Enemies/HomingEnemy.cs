using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    public GameObject target;
    private Rigidbody2D enemyRB;



    public float speed;
    public float rotateSpeed;

    void Start() {
        enemyRB = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate() {

        Vector2 direction = (Vector2)target.transform.position - enemyRB.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        enemyRB.angularVelocity = -rotateAmount * rotateSpeed;
       
        enemyRB.velocity = transform.up * speed;
    }
}
