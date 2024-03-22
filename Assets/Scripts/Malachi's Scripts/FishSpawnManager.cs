using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnManager : MonoBehaviour
{
    public GameObject FishPrefab;
    public Transform[] SpawnPos;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFish(spawnDelay));
    }

    // Update is called once per frame
    IEnumerator SpawnFish(float delayTime)
    {
        yield return new WaitForSeconds(spawnDelay);
        int randIndex = Random.Range(0, SpawnPos.Length);
        GameObject.Instantiate(FishPrefab, SpawnPos[randIndex].position, SpawnPos[randIndex].rotation * Quaternion.Euler(0,0,1f));
        StartCoroutine(SpawnFish(spawnDelay));
    }
}
