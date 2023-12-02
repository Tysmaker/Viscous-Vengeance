using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [Header("Portal Variables")]
    public GameObject portalPrefab;
    private Animator animator;
    private GameObject currentPortal;
    private bool portalSpawningStarted = false;
    public Transform[] portalSpawns;

    [Header("Enemy Variables")]
    public GameObject[] enemyPrefabs;
    public int currentEnemyCount;
    public int maxEnemyCount;
   

    // Update is called once per frame
    void Update()
    {
        if (currentEnemyCount < maxEnemyCount)
        {
            StartCoroutine(StartPortalSpawning());
        }
    }

    IEnumerator StartPortalSpawning()
    {
        if (!portalSpawningStarted)
        {
            portalSpawningStarted = true;

            yield return new WaitForSeconds(10);

            if (currentEnemyCount < maxEnemyCount)
            {
                RandomPortalSpawn();
            }
            portalSpawningStarted = false;
        }
    }

    private void RandomPortalSpawn()
    {
        int randomIndex = Random.Range(0, portalSpawns.Length);
        currentPortal = Instantiate(portalPrefab, portalSpawns[randomIndex].position, Quaternion.identity, transform);
        Invoke("SpawnEnemy", 5);
        animator = currentPortal.GetComponent<Animator>();
    }

    public void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomIndex].gameObject, currentPortal.transform.position, Quaternion.identity);
       Invoke("ClosePortal", 3);
    }

    private void ClosePortal()
    {
        animator.SetTrigger("ClosePortal");
        Destroy(currentPortal, 0.5f);
    }
}
