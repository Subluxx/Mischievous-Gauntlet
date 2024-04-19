using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
//using System.Numerics;

public class BirdSpawn : NetworkBehaviour
{
    [SerializeField] private GameObject spawnBehaviourPrefab;
    public GameObject Insta { get; private set; }
    public override void OnNetworkSpawn()
    {
        Insta = Instantiate(spawnBehaviourPrefab);
        Insta.GetComponent<NetworkObject>().Spawn();
        Insta.transform.position = new Vector3(-9.12f, -0.42f, 0);
    }
    public override void OnNetworkDespawn()
    {
        if (IsHost)
        {
            Insta.GetComponent<NetworkObject>().Despawn();
            base.OnNetworkDespawn();
        }
    }
}
