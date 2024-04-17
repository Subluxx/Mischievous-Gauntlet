using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class BirdSpawn : NetworkBehaviour
{
    [SerializeField] private GameObject spawnBehaviourPrefab;
    public GameObject Insta { get; private set; }
    public override void OnNetworkSpawn()
    {
        Insta = Instantiate(spawnBehaviourPrefab);
        Insta.GetComponent<NetworkObject>().Spawn();
    }
}
