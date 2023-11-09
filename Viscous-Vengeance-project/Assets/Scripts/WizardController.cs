using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : EnemyController
{
    [SerializeField] bool ShootFireBall;
    [SerializeField] public float fireBallInterval = 2.0f;

    public GameObject Fireball;


     void Start()
    {
        // Start shooting fireballs when the WizardController is enabled
        StartCoroutine(ShootFireballs());
    }

    void FixedUpdate()
    {
        
    }

    IEnumerator ShootFireballs()
    {
        while (ShootFireBall == true)
        {
            Speed = 0;
            //animator.SetBool("enemyAttack", true);
            Instantiate(Fireball, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(fireBallInterval);
        }
    }
}
