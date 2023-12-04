using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardFireBall : MonoBehaviour
{
    public float fireballSpeed;
    public int direction;
    private PlayerHealthBar playerHealthBar;
    private GameObject healthBarObject;

    public void Start()
    {
        InitializeHealth();
    }

    // Update is called once per frames
    void Update()
    {
        transform.position += ((transform.right * Time.deltaTime) * direction)* fireballSpeed;
    }

    public void InitializeHealth()
    {
        healthBarObject = GameObject.Find("Slime");
        playerHealthBar = healthBarObject.GetComponent<PlayerHealthBar>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealthBar.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}