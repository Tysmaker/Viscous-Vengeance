using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public float Speed;
    int xDirection;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    Collider2D col;
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        xDirection = -1; 
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        sr.flipX = true;
    }

    // Update is called once per frame
    void FixedUpdate() //only physics and movements
    {
        rb.velocity = new Vector2(Speed * xDirection, rb.velocity.y);
        if (xDirection == 1) 
        {
            sr.flipX = false;
        }
        else if (xDirection == -1)
        {
            sr.flipX = true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Attack"))
        {
            EnemyDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TurnAround"))
        {
            xDirection *= -1;
        }
    }

    public void EnemyDeath()
    {
        StartCoroutine(DeathTimer());
    }

    IEnumerator DeathTimer()
    {
        Destroy(rb);
        col.enabled = false;
        Speed = 0;
        animator.SetBool("enemyDeath", true);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
