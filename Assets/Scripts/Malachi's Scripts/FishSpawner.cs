
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class FishSpawnerBehaviour : MonoBehaviour
{
    public GameObject FishPrefab;
    [SerializeField] public float fireForce = 20f;
    [SerializeField] public float spawnDelay = 5.0f;
    [SerializeField] public int spawnDir = 0;
    public float rotationSpawn;
    public int FishSpawnChance;
    [SerializeField] public int MaxRand = 15;
    // Start is called before the first frame update

    private void Awake()
    {
        if (spawnDir == -1)
        {
            rotationSpawn = 0f;
        }
        else if (spawnDir == 1)
        {
            rotationSpawn = 90f;
        }
        StartCoroutine(SpawnFish(spawnDelay));
    }

    IEnumerator SpawnFish(float delayVar)
    {
        yield return new WaitForSeconds(delayVar);
        
            GameObject Fish = Instantiate(FishPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, rotationSpawn));
            //Fish.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
        
        StartCoroutine(SpawnFish(spawnDelay));
    }
}

