using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : EnemyController
{
    bool ShootFireBall;
    public float fireBallInterval = 2.0f;
    public bool isFacingLeft;
    public float fireballSpeed;
    int direction;

    //public Animator animator;

    public GameObject Fireball;


    private void Update()
    {
        StartCoroutine(ShootFireballs());
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
