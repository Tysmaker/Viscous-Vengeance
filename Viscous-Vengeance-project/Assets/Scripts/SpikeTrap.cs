using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public GameObject healthBarObject;   
    private PlayerHealthBar playerHealthBar;

    private void Start()
    {
        healthBarObject = GameObject.Find("Slime");
        playerHealthBar = healthBarObject.GetComponent<PlayerHealthBar>();      
    }





    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) 
         {
            playerHealthBar.TakeDamage(20);
        }

    }
}
