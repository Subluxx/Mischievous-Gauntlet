 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerNetwork : NetworkBehaviour {
    [SerializeField] private Transform platformObjectPrefab;
    public override void OnNetworkSpawn() {
        _ = Instantiate(platformObjectPrefab);
        platformObjectPrefab.GetComponent<NetworkObject>().Spawn(true);
    }
}

