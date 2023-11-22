using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryDoor : MonoBehaviour
{
    [SerializeField] private Transform destination;

    public Transform GoDestination()
    {
        return destination;
    }
  
}
