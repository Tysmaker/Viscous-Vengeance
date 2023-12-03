using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingPlatformController : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float timer;
    [SerializeField] int counter;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && transform.parent.GetComponent<MovingPlatformController>().direction == -1)
        { 
            StartCoroutine(addForce(collision));
        }
    }

    IEnumerator addForce(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 0; i < counter; i++)
        {
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0));
            yield return new WaitForSeconds(timer);
        }
        GetComponent<BoxCollider2D>().enabled = true;
    }

}
