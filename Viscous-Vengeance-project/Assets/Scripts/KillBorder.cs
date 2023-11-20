using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillBorder : MonoBehaviour
{
    public GameObject healthBarObject;
    private PlayerHealthBar playerHealthBar;

    private void Start()
    {
        healthBarObject = GameObject.Find("Slime");
        playerHealthBar = healthBarObject.GetComponent<PlayerHealthBar>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealthBar.TakeDamage(100);
        }

    }
}
