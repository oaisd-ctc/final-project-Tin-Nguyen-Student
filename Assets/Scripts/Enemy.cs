using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;
    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; 

        if (health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }

    void Update()
    {
    
    }
}


