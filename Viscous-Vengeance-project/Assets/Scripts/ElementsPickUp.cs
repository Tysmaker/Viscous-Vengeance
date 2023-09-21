using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementsPickUp : MonoBehaviour
{
  
    //Variables
    public Transform player;
    public TMP_Text text;
    [SerializeField] private int elementCount = 0;
    [SerializeField] private float pickUpSpeed;
    [SerializeField] private float pickUpDistance;


    private void Update()
    {
       //When player is within range of the pickUp, then the object will move towards the player
        if (player)
        {
            float dist = Vector3.Distance(player.position, transform.position);

            if(dist > pickUpDistance)
            {
                return;
            }
            else
            {
                var step = pickUpSpeed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, player.position, step);

            }
        }
    }

    //When enter the trigger of the gameobject we destroy the object, increase the elementCount and then update the text to be displayed in the UI.
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            elementCount++;
            text.text = elementCount.ToString();           
        }
    }       
}
