using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class SeaGullSpawnBehaviour : MonoBehaviour
{
    public GameObject SeaGullPrefab;
    public GameObject ParrotPrefab;
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

    private void Awake()
    {
        spawnPosition = transform.position;
        yMoving = transform.position.y;
        StartCoroutine(SpawnSeaGull(spawnDelay));
    }
    IEnumerator SpawnSeaGull(float delayVar)
    {
        yield return new WaitForSeconds(delayVar);
        ParrotSpawnChance = Random.Range(0, maxRand);
        if (ParrotSpawnChance == maxRand / 2)
        {
            GameObject parrot = Instantiate(ParrotPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
            parrot.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
        }
        else
        {
            GameObject SeaGull = Instantiate(SeaGullPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
            SeaGull.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
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
