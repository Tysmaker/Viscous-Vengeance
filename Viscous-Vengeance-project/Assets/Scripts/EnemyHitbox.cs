using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float BounceSpeed = 1350;
            GetComponentInParent<EnemyController>().EnemyDeath();
            if(collision.gameObject.GetComponent<PlayerController>().isJumping)
            {
                BounceSpeed = 1800;
            }
            Destroy(gameObject);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * BounceSpeed);
        }
    }  
}
