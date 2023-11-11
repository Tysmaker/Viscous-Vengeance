using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    private BoxCollider2D coll;
    private LayerMask groundLayer;
    public GameObject fireballPrefab;
    Vector3 fireballSpawnPoint;
    public bool isFacingLeft { get; private set; }

    private bool canFire;


    [SerializeField] ParticleSystem slimeSplat;
    [SerializeField] float Speed = 1;
    [SerializeField] float JumpSpeed = 1;
    [SerializeField] float DashSpeed = 1;
    [SerializeField] float SlamSpeed = 1;
    [SerializeField] float FireBallCoolDownTime = 1;

    private bool isMoving;
    private bool canSplat;

    public int FireCharges;
    public int WindCharges;
    public int LightningCharges;
    public int EarthCharges;

    float direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();

        groundLayer = LayerMask.GetMask("Ground");

        isFacingLeft = false;
        canFire = true;
        canSplat = false;

        FireCharges = 0;
        WindCharges = 0;
        LightningCharges = 0;
        EarthCharges = 0;

        fireballSpawnPoint = new Vector3(transform.position.x + 0.88f, transform.position.y - 0.14f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        SplatCheck();
        AnimationUpdate();
        ChargesUpdate();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * Speed, rb.velocity.y);
    }

    private void SplatCheck()
    {
        //fix here 
    }

    private void StopSlimeSplat()
    {
        canSplat = false;
        slimeSplat.Stop();
    }

    private void AnimationUpdate()
    {
        if (rb.velocity.x < 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else if (rb.velocity.x > 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else if (rb.velocity.x == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("IsGrounded", IsGrounded());
    }

    private void ChargesUpdate()
    {

    }

    void Flip()
    {
        sr.flipX = isFacingLeft;
        if (isFacingLeft)
        {
            fireballSpawnPoint = new Vector3(transform.position.x - 0.88f, transform.position.y - 0.14f, 0);
        }
        else
        {
            fireballSpawnPoint = new Vector3(transform.position.x + 0.88f, transform.position.y - 0.14f, 0);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 contextVector = context.ReadValue<Vector2>();
        if (contextVector.x < 0)
        {
            direction = -1;
            isFacingLeft = true;
        }
        else if (contextVector.x > 0)
        {
            direction = 1;
            isFacingLeft = false;
        }
        else
        {
            direction = 0;
        }
    }

    public void Fireball(InputAction.CallbackContext context)
    {
        if (context.started && canFire)
        {
            var fireball = Instantiate(fireballPrefab, fireballSpawnPoint, transform.rotation);
            fireball.transform.parent = gameObject.transform;
            canFire = false;
            Invoke("FireBallCoolDown", FireBallCoolDownTime);
        }
    }

    void FireBallCoolDown()
    {
        canFire = true;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            rb.AddForce(new Vector2(direction * DashSpeed, 0));
        }
    }

    public void Slam(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            rb.AddForce(new Vector2(0, -SlamSpeed));
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
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }
}
