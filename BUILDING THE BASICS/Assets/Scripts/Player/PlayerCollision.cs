using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool consistentContact = false;


    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        InvokeRepeating("ConsistentContactSwitch", 0f, 0.4f);
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }

    }

    private void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Enemy")
        {
            if (consistentContact == true)
            {
                TakeDamage(5);
                consistentContact = false;
            }
        }

    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void ConsistentContactSwitch()
    {
        consistentContact = true;
    }
}
