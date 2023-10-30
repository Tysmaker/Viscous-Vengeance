using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float fireballSpeed;
    
    // Update is called once per frame
    void Update()
    {

        transform.position += transform.right * Time.deltaTime * fireballSpeed;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
