using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : EnemyController
{
    [SerializeField] bool ShootFireBall;
    [SerializeField] public float fireBallInterval = 2.0f;
    public bool isFacingLeft;
    public float fireballSpeed;
    private WizardController enemy;
    SpriteRenderer sr;
    int direction;
    Animator animator;

    //public Animator animator;

    public GameObject Fireball;


     void Start()
    {
        enemy = GetComponent<WizardController>();
        animator = GetComponentInParent<Animator>();
        //animator = GetComponentInParent<Animator>();
        // Start shooting fireballs when the WizardController is enabled
        StartCoroutine(ShootFireballs());
        isFacingLeft = true;
        sr = gameObject.GetComponent<SpriteRenderer>();
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

    void FixedUpdate()
    {
        transform.position += transform.right * Time.deltaTime * fireballSpeed * direction;
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
