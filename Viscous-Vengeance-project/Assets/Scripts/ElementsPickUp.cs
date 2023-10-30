using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementsPickUp : MonoBehaviour
{

    //Variables
    public Transform player;

    [SerializeField] private float pickUpSpeed;
    private float radius = 3f;
    private LayerMask playerLayer;
    private bool collect;
    public ElementsUIPoints elementsUIPoints;
    //[SerializeField] ParticleSystem pickUpEffect;

    private void Start()
    {
        playerLayer = LayerMask.GetMask("Player");
       
    }

    private void Update()
    {
        if(IsInRange())
        {
            collect = true;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        if (collect)
        {
            float step = pickUpSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
    }

    //When enter the trigger of the gameobject we destroy the object, increase the elementCount and then update the text to be displayed in the UI.
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            elementsUIPoints.elementScore++;

            //pickUpEffect.Play();

           Destroy(gameObject,1f);
        }
    }

    private bool IsInRange()
    {
        return Physics2D.OverlapCircle(transform.position, radius, playerLayer);    
    }
    //Enable for testing
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(transform.position, radius);
    //}
}

  
