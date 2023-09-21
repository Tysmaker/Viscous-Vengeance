using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementsPickUp : MonoBehaviour
{
    //Variables
    public Transform player;
    public Transform pickUp;
    public TMP_Text text;
    public int elementCount = 0;
    public float pickUpSpeed;
    public float pickUpDistance;
    private Rigidbody2D rb;

    //Created a Vector 3 Method that takes min and max arguments
    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        return new Vector3(x,0,0);
    }

    //When the game starts get the rigidibody and send it in a random direction on the x between -1f && 1f.
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = RandomVector(-1f, 1f);
    }

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
                Destroy(rb);
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
