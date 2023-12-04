using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardFireBall : MonoBehaviour
{
    public float fireballSpeed;
    public int direction;

    public void Start()
    {

    }

    // Update is called once per frames
    void Update()
    {
        transform.position += ((transform.right * Time.deltaTime) * direction)* fireballSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthBar>().TakeDamage(20);
            Destroy(gameObject);
        }
        if(collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }
}
