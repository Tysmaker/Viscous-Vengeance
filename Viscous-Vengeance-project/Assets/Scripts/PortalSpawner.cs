using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject portalPrefab;
    private Animator animator;
    public Transform[] portalSpawns;
    private GameObject currentPortal;
    public GameObject[] enemyPrefabs;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomPortalSpawn", 5, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomIndex].gameObject, currentPortal.transform.position, Quaternion.identity);
        //gonna instaniate the enemy
       Invoke("ClosePortal", 5);
    }

    private void RandomPortalSpawn()
    {
        int randomIndex = Random.Range(0, portalSpawns.Length);
       currentPortal = Instantiate(portalPrefab, portalSpawns[randomIndex].position, Quaternion.identity, transform);
        Invoke("SpawnEnemy", 5);
        animator = currentPortal.GetComponent<Animator>(); 
        //portalSpawns.transform.parent = gameObject.transform;
    }

    private void ClosePortal()
    {
        animator.SetTrigger("ClosePortal");

        Destroy(currentPortal, 1);
    }
}
