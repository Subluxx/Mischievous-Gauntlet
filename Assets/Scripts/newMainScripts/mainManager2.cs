using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;
using UnityEngine.SceneManagement;

public class mainManager2 : NetworkBehaviour
{
    // Start is called before the first frame update
    //[SerializeField]
    //private string m_SceneName;
    //private Scene m_LoadedScene;
    private Scene loadedScene;
    void Start()
    {
        //set index value in new manager to 0 -> this ensures the first minigame to play will be the first item in the currentGameSceneOrder list
        newManager.index = 0;
        //when this scene loads, add the scene names to the list found in newManager.
        newManager.addScenesToGame();
    }

    // Update is called once per frame
    void Update()
    {
        newManager.debug1();
        Debug.Log($"index value is {newManager.index}");
    }

    public void loadGame()
    {
        //newManager.loadGame();
    }
    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            NetworkManager.SceneManager.LoadScene("playerLobby", LoadSceneMode.Additive);
            UnloadScene();

        }
        
    }

    public void UnloadScene()
    {
        //NetworkManager.SceneManager.Unload();
        // Assure only the server calls this when the NetworkObject is
        // spawned and the scene is loaded.
        //if (!IsServer || !IsSpawned || !loadedScene.IsValid() || !loadedScene.isLoaded)
        //{
        //    return;
        //}

        // Unload the scene
        //NetworkManager.SceneManager.UnloadScene("menuTest");
        //CheckStatus(status, false);
        NetworkManager.SceneManager.UnloadScene(loadedScene);
    }
}
