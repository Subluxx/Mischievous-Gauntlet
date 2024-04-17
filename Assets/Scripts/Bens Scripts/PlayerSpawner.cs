using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

public class PlayerSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject playerPrefabLobby; //add prefab in inspector
    [SerializeField] private GameObject playerPrefabBen; //add prefab in inspector
    [SerializeField] private GameObject playerPrefabJan; //add prefab in inspector
    [SerializeField] private GameObject playerPrefabJoe; //add prefab in inspector
    [SerializeField] private GameObject playerPrefabOllie; //add prefab in inspector
    public string _scene;
    //public mainManager2 m;
    GameObject newPlayer;
    NetworkObject netObj;
    [ServerRpc(RequireOwnership = false)] //server owns this object but client can request a spawn
    public void SpawnPlayerServerRpc(ulong clientId, int prefabId)
    {
        //mainManager2 = mainManagerObj.GetComponent<MainManager2>();
        if(newManager._scene == null)
        {
            _scene = "playerLobby";
        }
        else
        {
            _scene = newManager._scene;
        }
        Debug.Log(_scene);
        //CurrentScene = mainManager2.currentScene;
        if (prefabId == 0 && string.Equals(_scene, "playerLobby"))
        {
            newPlayer = (GameObject)Instantiate(playerPrefabLobby);
        }
        else if (string.Equals(_scene, "benScene"))
        {
            newPlayer = (GameObject)Instantiate(playerPrefabBen);
        }
        else if (string.Equals(_scene, "joeScene"))
        {
            newPlayer = (GameObject)Instantiate(playerPrefabJoe);
        }
        //newPlayer = (GameObject)Instantiate(playerPrefabB);
        netObj = newPlayer.GetComponent<NetworkObject>();
        newPlayer.SetActive(true);
        netObj.SpawnAsPlayerObject(clientId, true);
    }
    public override void OnNetworkSpawn()
    {
        SpawnPlayerServerRpc(0, 0);
    }
    public void sceneChange()
    {
        SpawnPlayerServerRpc(0, 0);
        Debug.Log("as written");
    }
}
