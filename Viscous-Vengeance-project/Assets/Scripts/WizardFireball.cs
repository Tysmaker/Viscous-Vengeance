using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardFireBall : MonoBehaviour
{
    public float fireballSpeed;
    private WizardController parent;
    SpriteRenderer sr;
    int direction;

    public void Start()
    {
        parent = gameObject.transform.parent.GetComponent<WizardController>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        if (parent.isFacingLeft)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        sr.flipX = parent.isFacingLeft;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * fireballSpeed * direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            //Destroy(gameObject);
        }
    }
}
