using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;

     void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0) 
        { 
        Destroy(gameObject);
        }
    }
    public int currentMaxHealth;
    public int currentHealth;
    public int dmgAmount;
    Rigidbody2D myRigidbody;
    public Animator anim;
    Rigidbody2D rb;
    
    public int Healths
    {
      get
      {
        return currentHealth;
      
      }
      set
      {
        currentHealth = value;
      }
    }
    public int MaxHealth
    {
      get
      {
        return currentMaxHealth;
      
      }
      set
      {
        currentMaxHealth = value;
      }
    }
    public void UnitHealth(int health, int maxHealth)
    {
      currentHealth = health;
      currentMaxHealth = maxHealth;
    }

    public void DmgUnit(int dmgAmount)
    {
      if (currentHealth > 0)
      {
        currentHealth -= dmgAmount;
      }
    }
    public void HealUnit(int healAmount)
    {
      if (currentHealth < currentMaxHealth)
      {
        currentHealth += dmgAmount;
      }
      if (currentHealth > currentMaxHealth)
      {
        currentHealth = currentMaxHealth;
      }
    }
  public int GetHealth()
    {
        return currentHealth;
    }
}
