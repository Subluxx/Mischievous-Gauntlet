using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class SeaGullSpawnBehaviour : MonoBehaviour
{
    public GameObject SeaGullPrefab;
    [SerializeField] public float fireForce = 20f;
    [SerializeField] public float spawnDelay = 5.0f;
    [SerializeField] public int spawnDir = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        StartCoroutine(SpawnSeaGull(spawnDelay));
    }

    IEnumerator SpawnSeaGull(float delayVar)
    {
        yield return new WaitForSeconds(delayVar);
        if(spawnDir == -1)
        {
            GameObject SeaGull = Instantiate(SeaGullPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 0f));
            SeaGull.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
            StartCoroutine(SpawnSeaGull(spawnDelay));
        }
        else if(spawnDir == 1)
        {
            GameObject SeaGull = Instantiate(SeaGullPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90f));
            SeaGull.GetComponent<Rigidbody2D>().AddForce(transform.right * fireForce, ForceMode2D.Impulse);
            StartCoroutine(SpawnSeaGull(spawnDelay));
        }
        else
        {
            StartCoroutine(SpawnSeaGull(spawnDelay));
        }
        
    }
}
