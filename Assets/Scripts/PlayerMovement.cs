using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] Vector2 deathKick = new Vector2 (10f, 10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    private Vector2 moveDirection;
    public float moveSpeed = 1f;

    Vector2 movement;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;

    bool isAlive = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    void Update()
    {if (!isAlive) { return; }
        Die();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        myAnimator.SetFloat("Horizontal", movement.x);
        myAnimator.SetFloat("Vertical", movement.y);
        myAnimator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + movement * moveSpeed);
    }
    void OnFire(InputValue value)
    {
        if (!isAlive) { return; }
        Instantiate(bullet, gun.position, transform.rotation);
    }
    
    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }


    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            isAlive = false;
          myAnimator.SetTrigger("IsDead");
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
       }
    }
}
