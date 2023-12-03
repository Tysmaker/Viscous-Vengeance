using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : EnemyController
{
    private Vector3 fireballSpawnPoint;
    public float fireBallInterval = 5f;
    private bool isShooting = false;
    public float fireballSpeed;
    public GameObject Fireball;

    private void Update()
    {
        
        StartCoroutine(ShootFireballs());
    }

    IEnumerator ShootFireballs()
    {
        if (!isShooting)
        {
            isShooting = true;
            
            yield return new WaitForSeconds(fireBallInterval);

            if(isFacingLeft)
            {
                fireballSpawnPoint = new Vector3(transform.position.x - 0.88f, transform.position.y + 0.65f, 0);
            }
            else
            {
                fireballSpawnPoint = new Vector3(transform.position.x + 0.88f, transform.position.y + 0.65f, 0);
            }
           
            //Speed = 0;
            animator.SetBool("ShootFireBall", true);
            var fireball = Instantiate(Fireball, fireballSpawnPoint, transform.rotation); ;
            //fireball.transform.parent = gameObject.transform;
            var fireballScript = fireball.GetComponent<WizardFireBall>();
            if(isFacingLeft)
            {
                fireballScript.direction = -1;
            }
            else
            {
                fireballScript.direction = 1;
            }
            
            isShooting = false; 
        }     
    }
}   
