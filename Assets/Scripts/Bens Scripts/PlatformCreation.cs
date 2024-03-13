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
    [SerializeField] private Transform endPlatform;
    [SerializeField] private int endPoint;
    private int platformSelector;
    public Transform Insta { get; private set; }
    public GameObject Insta2 { get; private set; }
    public Transform Insta3 { get; private set; }
    public override void OnNetworkSpawn()
    {
        Insta = Instantiate(platformObjectPrefab);
        Insta.GetComponent<NetworkObject>().Spawn();
        Insta3 = Instantiate(endPlatform);
        Insta3.GetComponent<NetworkObject>().Spawn();
        //for (int i = 0; i < Platforms.Length; i++)
        //{
        //    Insta2 = Instantiate(Platforms[i]);
        //    Insta2.GetComponent<NetworkObject>().Spawn();
        //}
        //Insta3 = Instantiate(endPlatform);
        //Insta3.GetComponent<NetworkObject>().Spawn();
    }
    void Start()
    {
        previousPosition = platformObjectPrefab.transform.position.x;
        //Debug.Log(platformSelector);
        platformWidths = new float[Platforms.Length];
        for (int i = 0; i < Platforms.Length; i++)
        {
            platformWidths[i] = Platforms[i].GetComponent<BoxCollider2D>().size.x;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (previousPosition < endPoint)
        {
            //Debug.Log("working");
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, Platforms.Length);
            Insta2 = Instantiate(Platforms[platformSelector]);
            Insta2.GetComponent<NetworkObject>().Spawn();
            Insta2.transform.position = new Vector3(previousPosition + platformWidths[platformSelector] + distanceBetween+10, 0, 0);
            //transform.position = new Vector3(transform.position.x+platformWidth+distanceBetween,)
            previousPosition = Insta2.transform.position.x;
        }
        else
        {
            Insta3.transform.position = new Vector3(previousPosition + platformWidths[platformSelector] + distanceBetween + 10, 0, 0);
        }
    }
}

