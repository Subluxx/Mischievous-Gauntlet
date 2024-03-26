using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeaGullSpawnBehaviour : NetworkBehaviour
{
    [SerializeField] private GameObject SeaGullPrefab;
    [SerializeField] private GameObject ParrotPrefab;
    public GameObject InstantiateSeagull { get; private set; }
    public GameObject InstantiateParrot { get; private set; }
    
    [SerializeField] public float fireForce = 20f;
    [SerializeField] public float spawnDelay = 5.0f;
    [SerializeField] public bool FlyingRight;
    public int ParrotSpawnChance;
    [SerializeField] public int maxRand;
    Vector3 spawnPosition;
    float yMoving;
    bool ymovingup = false;
    [SerializeField] float boundingArea;
    // Start is called before the first frame update

    public override void OnNetworkSpawn() 
    {
        spawnPosition = transform.position;
        yMoving = transform.position.y;

        InstantiateSeagull = Instantiate(SeaGullPrefab);
        InstantiateParrot = Instantiate(ParrotPrefab);
        
        StartCoroutine(SpawnSeaGull(spawnDelay));
    }
    IEnumerator SpawnSeaGull(float delayVar)
    {
        yield return new WaitForSeconds(delayVar);
        ParrotSpawnChance = Random.Range(0, maxRand);
        if (ParrotSpawnChance == maxRand / 2)
        {
            InstantiateParrot.GetComponent<NetworkObject>().Spawn();
            InstantiateParrot.transform.position = new Vector3(transform.position.x,transform.position.y);
            InstantiateParrot.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce * 1.5f, ForceMode2D.Impulse);
        }
        else
        {
            InstantiateSeagull.GetComponent<NetworkObject>().Spawn();
            InstantiateSeagull.transform.position = new Vector3(transform.position.x,transform.position.y);
            InstantiateSeagull.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
        }
        if (yMoving > spawnPosition.y + boundingArea)
        {
            ymovingup = true;
        }
        else if (yMoving < spawnPosition.y - boundingArea + boundingArea)
        {
            ymovingup = false;
        }
        if (!ymovingup)
        {
            yMoving += 1f;
        }
        else
        {
            yMoving -= 1f;
        }
        transform.localPosition = new Vector3(spawnPosition.x, yMoving, spawnPosition.z);
        StartCoroutine(SpawnSeaGull(spawnDelay));
    }
}
