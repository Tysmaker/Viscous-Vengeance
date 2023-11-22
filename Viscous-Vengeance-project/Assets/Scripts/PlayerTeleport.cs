using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentDoor;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentDoor != null) 
            {
                transform.position = currentDoor.GetComponent<MysteryDoor>().GoDestination().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            currentDoor = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            if (collision.gameObject == currentDoor) 
            { 
                currentDoor = null;
            }
        }
    }
}
