 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerNetwork : NetworkBehaviour {
    [SerializeField] private Transform platformObjectPrefab;

    public Transform Insta { get; private set; }

    public override void OnNetworkSpawn() {
        Insta = Instantiate(platformObjectPrefab);
        Insta.GetComponent<NetworkObject>().Spawn();
    }
}

