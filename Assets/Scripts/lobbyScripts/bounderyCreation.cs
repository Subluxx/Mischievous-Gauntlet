using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class bounderyCreation : NetworkBehaviour
{
    [SerializeField] private Transform invisPlatformPrefab;
    [SerializeField] private GameObject invisWallPrefab;
    public Transform Insta { get; private set; }
    public GameObject Insta2 { get; private set; }
    public override void OnNetworkSpawn()
    {
        Insta = Instantiate(invisPlatformPrefab);
        Insta.GetComponent<NetworkObject>().Spawn();
        for(int i = 0; i<2; i++)
        {
            Insta2 = Instantiate(invisWallPrefab);
            Insta2.GetComponent<NetworkObject>().Spawn();
            if (i == 0)
            {
                Insta2.transform.position = new Vector3(-7.73f, 0, 0);
            }
            else
            {
                Insta2.transform.position = new Vector3(7.69f, 0, 0);
            }
        }
    }
    public override void OnNetworkDespawn()
    {
        Insta.GetComponent<NetworkObject>().Despawn();
        Insta2.GetComponent<NetworkObject>().Despawn();
        base.OnNetworkDespawn();
    }
}
