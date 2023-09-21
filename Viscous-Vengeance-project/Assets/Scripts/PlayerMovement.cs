using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    [SerializeField] float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
            animator.SetBool("IsMoving", true);
        }
        else if (rb.velocity.x > 0)
        {
            sr.flipX = false;
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 contextVector = context.ReadValue<Vector2>();
        float direction;
        if (contextVector.x < 0)
        {
            direction = -1;
        }
        else if (contextVector.x > 0)
        {
            direction = 1;
        }
        else {
            direction = 0;
        }


        rb.velocity = new Vector2( direction * Speed, rb.velocity.y);
    }
}
