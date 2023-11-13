using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public float Speed;
    
    public int xDirection;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;
    public Collider2D col;

    public GameObject healthBarObject;
    private PlayerHealthBar playerHealthBar;

    public GameObject Pickup;
    // Start is called before the first frame update
    public void Start()
    {
        xDirection = -1; 
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        sr.flipX = true;
        InitializeHealth();
    }

    // Update is called once per frame
    public void FixedUpdate() //only physics and movements
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(Speed * xDirection, rb.velocity.y);
        }
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
        else if (collision.gameObject.CompareTag("Player")){
            animator.SetBool("enemyClose", true);
            playerHealthBar.TakeDamage(20);
            if (collision.gameObject.transform.position.x < transform.position.x)
            {
                xDirection = -1;
            }
            else if (collision.gameObject.transform.position.x > transform.position.x)
            {
                xDirection = 1;
            }
        }
    }

    public void InitializeHealth()
    {
        healthBarObject = GameObject.Find("Slime");
        playerHealthBar = healthBarObject.GetComponent<PlayerHealthBar>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            animator.SetBool("enemyClose", false);
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

    public void PickupCreation()
    {
        Instantiate(Pickup);        
        Instantiate(Pickup);
    }

    IEnumerator DeathTimer()
    {
        PickupCreation();
        Destroy(rb);
        col.enabled = false;
        Speed = 0;
        animator.SetBool("enemyDeath", true);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
