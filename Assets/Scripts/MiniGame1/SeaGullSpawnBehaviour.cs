using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class SeaGullSpawnBehaviour : MonoBehaviour
{
    public GameObject SeaGullPrefab;
    public GameObject ParrotPrefab;
    [SerializeField] public float fireForce = 20f;
    [SerializeField] public float spawnDelay = 5.0f;
    [SerializeField] public int spawnDir = 0;
    public float rotationSpawn;
    public int ParrotSpawnChance;
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
        StartCoroutine(SpawnSeaGull(spawnDelay));
    }

    IEnumerator SpawnSeaGull(float delayVar)
    {
        yield return new WaitForSeconds(delayVar);
        ParrotSpawnChance = Random.Range(0, MaxRand);
        if (ParrotSpawnChance == MaxRand - 1)
        {
            GameObject parrot = Instantiate(ParrotPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, rotationSpawn));
            parrot.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
        }
        else
        {
            GameObject SeaGull = Instantiate(SeaGullPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, rotationSpawn));
            SeaGull.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
        }
        StartCoroutine(SpawnSeaGull(spawnDelay));
    }
}
