using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    private BoxCollider2D coll;
    private LayerMask groundLayer;
    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;
    bool isFacingRight = true;


    [SerializeField] ParticleSystem slimeSplat;
    [SerializeField] float Speed = 1;
    [SerializeField] float JumpSpeed = 1;
    
    private bool isMoving;
    float direction;

    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            slimeSplat.Play();
            Invoke("StopSlimeSplat", 1f);
        }

        //Debug.Log(rb.velocity);
        AnimationUpdate();
    }

    private void FixedUpdate()
    {

        MoveCheck();
        
    }

    private void StopSlimeSplat()
    {
        slimeSplat.Stop();
    }

    private void AnimationUpdate()
    {
        if (rb.velocity.x < 0 && isFacingRight)
        {
            Flip();
            animator.SetBool("IsMoving", true);
        }
        else if (rb.velocity.x > 0 && !isFacingRight)
        {
            Flip();
            animator.SetBool("IsMoving", true);
        }
        else if(rb.velocity.x == 0)
        { 
            animator.SetBool("IsMoving", false);
        }

        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("IsGrounded", IsGrounded());
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Move(InputAction.CallbackContext context)
    {
      
        Vector2 contextVector = context.ReadValue<Vector2>();
        if (contextVector.x < 0)
        {
            direction = -1;
         
        }
        else if (contextVector.x > 0)
        {
            direction = 1;
           
        }       
        else
        {
            direction = 0;
        }
    }

    public void Fireball(InputAction.CallbackContext context)
    {
       if(context.started)
        {
           Instantiate(fireballPrefab, fireballSpawnPoint.position, transform.rotation);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);  
        } 
        if (context.canceled && rb.velocity.y > 0) 
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
   
    private void MoveCheck()
    {
        rb.velocity = new Vector2(direction * Speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }
}
 