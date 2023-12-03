using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : EnemyController
{
    private Vector3 fireballSpawnPoint;
    bool ShootFireBall;
    public float fireBallInterval = 2.0f;
    public bool isFacingLeft { get; private set; }
    public float fireballSpeed;
    int direction;

    //public Animator animator;

    public GameObject Fireball;


    private void Update()
    {
        Flip();
        StartCoroutine(ShootFireballs());
    }

    void Flip()
    {
        sr.flipX = !isFacingLeft;
        if (!isFacingLeft)
        {
            fireballSpawnPoint = new Vector3(transform.position.x - 0.88f, transform.position.y - 0.14f, 0);
        }
        else
        {
            fireballSpawnPoint = new Vector3(transform.position.x + 0.88f, transform.position.y - 0.14f, 0);
        }
    }
    IEnumerator ShootFireballs()
    {
        //while (ShootFireBall == true)
        //{
        fireballSpawnPoint = new Vector3(transform.position.x + 0.88f, transform.position.y + 0.65f, 0);
        Speed = 0;
        animator.SetBool("enemyAttack", true);
        var fireball = Instantiate(Fireball, fireballSpawnPoint , transform.rotation); ;
        fireball.transform.parent = gameObject.transform;
        yield return new WaitForSeconds(fireBallInterval);
        
        //}
    }
}   
