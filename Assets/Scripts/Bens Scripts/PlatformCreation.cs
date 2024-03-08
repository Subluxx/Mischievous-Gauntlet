using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlatformCreation : NetworkBehaviour
{
    private float[] platformWidths;
    private float platformHeight;
    private float distanceBetween;
    private float previousPosition;
    [SerializeField] private float distanceBetweenMin;
    [SerializeField] private float distanceBetweenMax;
    [SerializeField] private Transform platformObjectPrefab;
    [SerializeField] private GameObject[] Platforms;
    [SerializeField] private Transform endPoint;
    private int platformSelector;
    public Transform Insta { get; private set; }
    public GameObject Insta2 { get; private set; }
    public Transform Insta3 { get; private set; }
    public override void OnNetworkSpawn()
    {
        Insta = Instantiate(platformObjectPrefab);
        Insta.GetComponent<NetworkObject>().Spawn();
        for (int i = 0; i < Platforms.Length; i++)
        {
            Insta2 = Instantiate(Platforms[i]);
            Insta2.GetComponent<NetworkObject>().Spawn();
        }
        Insta3 = Instantiate(endPoint);
        Insta3.GetComponent<NetworkObject>().Spawn();
    }
    void Start()
    {
        previousPosition = Platforms[platformSelector].transform.position.x;
        platformWidths = new float[Platforms.Length];
        for (int i = 0; i < Platforms.Length; i++)
        {
            platformWidths[i] = Platforms[i].GetComponent<BoxCollider2D>().size.x;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Platforms[platformSelector].transform.position.x < endPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, Platforms.Length);
            Platforms[platformSelector].transform.position = new Vector3(previousPosition + platformWidths[platformSelector] + distanceBetween, 0, 0);
            //transform.position = new Vector3(transform.position.x+platformWidth+distanceBetween,)
            previousPosition = Platforms[platformSelector].transform.position.x;
        }
    }
}

