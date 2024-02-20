using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerNetwork : NetworkBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private Transform platformObjectPrefab;
    void FixedUpdate() {
        if (IsLocalPlayer) {
            float movement = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(movement * speed, 0.0f);
        }
    }
    public override void OnNetworkSpawn() {
        _ = Instantiate(platformObjectPrefab);
        platformObjectPrefab.GetComponent<NetworkObject>().Spawn(true);
    }
}

