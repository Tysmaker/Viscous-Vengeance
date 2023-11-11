using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHitbox : MonoBehaviour
{
    float BounceSpeed = 1350;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * BounceSpeed);
            GetComponentInParent<EnemyController>().EnemyDeath();
            Destroy(gameObject);
        }
    }  
}
