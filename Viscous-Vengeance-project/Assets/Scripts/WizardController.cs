using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : EnemyController
{
    bool ShootFireBall;
    public float fireBallInterval = 2.0f;
    public bool isFacingLeft;
    public float fireballSpeed;
    private WizardController enemy;
    int direction;

    //public Animator animator;

    public GameObject Fireball;

    new void Start()
    {
        xDirection = -1;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        sr.flipX = true;
        enemy = GetComponent<WizardController>();
        //animator = GetComponentInParent<Animator>();
        // Start shooting fireballs when the WizardController is enabled
        StartCoroutine(ShootFireballs());
        isFacingLeft = true;
        sr = gameObject.GetComponent<SpriteRenderer>();
        InitializeHealth();


        if (enemy.isFacingLeft)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        sr.flipX = enemy.isFacingLeft;
    }

    IEnumerator ShootFireballs()
    {
        while (ShootFireBall)
        {
            Speed = 0;
            animator.SetBool("enemyAttack", true);
            Instantiate(Fireball, new Vector3(transform.position.x - 0.88f, transform.position.y - 0.14f, 0), Quaternion.identity);
            yield return new WaitForSeconds(fireBallInterval);
        }
    }
}
