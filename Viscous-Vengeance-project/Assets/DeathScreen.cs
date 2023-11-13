using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathPanelObject;
    private GameObject healthBarObject;
    private PlayerHealthBar healthBar;
    //private Animator animator;
    


    // Start is called before the first frame update
    void Start()
    {
        //deathPanelObject = GameObject.Find("DeathScreen/DeathPanel");
        healthBarObject = GameObject.Find("Slime");
        healthBar = healthBarObject.GetComponent<PlayerHealthBar>();   
        //animator = deathPanelObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar.currentHealth <= 0)
        {
            deathPanelObject.SetActive(true);
            //This can be changed if we dont want to pause game when we die.
            //Time.timeScale = 0;

            
            //animator.SetTrigger("Dead");
        }
        
    }
}
