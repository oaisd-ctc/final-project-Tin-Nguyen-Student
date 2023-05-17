using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
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
  
}
