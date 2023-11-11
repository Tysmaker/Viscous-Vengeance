using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ElementsPickUp : MonoBehaviour
{

    //Variables
    GameObject player;

    [SerializeField] private float pickUpSpeed;
    private float radius = 3f;
    private LayerMask playerLayer;
    private bool collect;
    public ElementsUIPoints elementsUIPoints;

    //[SerializeField] ParticleSystem pickUpEffect;

    private void Start()
    {
        playerLayer = LayerMask.GetMask("Player");
        player = GameObject.Find("Slime");
        elementsUIPoints = GameObject.Find("Elements").GetComponent<ElementsUIPoints>();
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
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    //When enter the trigger of the gameobject we destroy the object, increase the elementCount and then update the text to be displayed in the UI.
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            AddCharge(gameObject.name);
           //pickUpEffect.Play();
           Destroy(gameObject);
        }
    }

    public void AddCharge(string name)
    {
        PlayerController pc = player.GetComponent<PlayerController>();
        switch (name)
        {
            case "Fire(Clone)":
                elementsUIPoints.FireCharges++;
                pc.FireCharges++;
                break;
            case "Wind(Clone)":
                elementsUIPoints.WindCharges++;
                pc.WindCharges++;
                break;
            case "Lightning(Clone)":
                elementsUIPoints.LightningCharges++;
                pc.LightningCharges++;
                break;
            case "Earth(Clone)":
                elementsUIPoints.EarthCharges++;
                pc.EarthCharges++;
                break;                          
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

  
