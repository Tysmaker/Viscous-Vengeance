using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHitbox : MonoBehaviour
{
   
    private GameObject parent;
    

    // Start is called before the first frame update
    void Start()
    {       
    }

    // Update is called once per frame
    void FixedUpdate() //only physics and movements
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<EnemyController>().EnemyDeath();
        }
    }  
}
