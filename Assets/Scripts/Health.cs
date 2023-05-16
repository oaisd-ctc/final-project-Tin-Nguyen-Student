using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    Rigidbody2D myRigidbody;
    public Animator anim;
    void Start()
    {
        currentHealth = 1;
    }

      void TakeDamage(int amount)
      {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            anim.SetBool("IsDead", true);
        }
      }
      private void OnTriggerEnter2D(Collider2D collision) 
      {
        if (collision.tag != "Bullet")
        {
            gameObject.transform.parent = collision.gameObject.transform;
            Destroy(GetComponent<myRigidbody>());
            GetComponent<myRigidBody>().enabled = false;
        }
        if (collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }
        }
        //void Heal(int amount)
      //{
        //currentHealth -= amount;

        //if(currentHealth <= maxHealth)
        //{
        //    currentHealth = maxHealth;
        //}
      //}

      }
}
