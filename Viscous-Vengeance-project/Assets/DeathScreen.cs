using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathPanelObject;
    private GameObject healthBarObject;
    private PlayerHealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBarObject = GameObject.Find("Slime");
        healthBar = healthBarObject.GetComponent<PlayerHealthBar>();       
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar.currentHealth <= 0)
        {
            deathPanelObject.SetActive(true);
        }
        
    }
}
