using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class mainManager2 : NetworkBehaviour
{
    // Start is called before the first frame update
    public string m_SceneName;
    private Scene m_LoadedScene;
    [SerializeField] private Button switcherBtn;
    public bool SceneIsLoaded
    {
        get
        {
            if (m_LoadedScene.IsValid() && m_LoadedScene.isLoaded)
            {
                return true;
            }
            return false;
        }
    }
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
        //newManager.debug1();
        //Debug.Log($"index value is {newManager.index}");
    }

    public void loadGame()
    {
        //newManager.loadGame();
    }
    public override void OnNetworkSpawn()
    {
        if (IsServer && !string.IsNullOrEmpty(m_SceneName))
        {
            NetworkManager.SceneManager.OnSceneEvent += SceneManager_OnSceneEvent;
          //var status = NetworkManager.SceneManager.LoadScene(m_SceneName, LoadSceneMode.Additive);
            //CheckStatus(status);
        }

        base.OnNetworkSpawn();

    }
    private void CheckStatus(SceneEventProgressStatus status, bool isLoading = true)
    {
        var sceneEventAction = isLoading ? "load" : "unload";
        if (status != SceneEventProgressStatus.Started)
        {
            Debug.LogWarning($"Failed to {sceneEventAction} {m_SceneName} with" +
                $" a {nameof(SceneEventProgressStatus)}: {status}");
        }
    }
    private void SceneManager_OnSceneEvent(SceneEvent sceneEvent)
    {
        var clientOrServer = sceneEvent.ClientId == NetworkManager.ServerClientId ? "server" : "client";
        switch (sceneEvent.SceneEventType)
        {
            case SceneEventType.LoadComplete:
                {
                    // We want to handle this for only the server-side
                    if (sceneEvent.ClientId == NetworkManager.ServerClientId)
                    {
                        // *** IMPORTANT ***
                        // Keep track of the loaded scene, you need this to unload it
                        m_LoadedScene = sceneEvent.Scene;
                    }
                    Debug.Log($"Loaded the {sceneEvent.SceneName} scene on " +
                        $"{clientOrServer}-({sceneEvent.ClientId}).");
                    break;
                }
            case SceneEventType.UnloadComplete:
                {
                    Debug.Log($"Unloaded the {sceneEvent.SceneName} scene on " +
                        $"{clientOrServer}-({sceneEvent.ClientId}).");
                    break;
                }
            case SceneEventType.LoadEventCompleted:
            case SceneEventType.UnloadEventCompleted:
                {
                    var loadUnload = sceneEvent.SceneEventType == SceneEventType.LoadEventCompleted ? "Load" : "Unload";
                    Debug.Log($"{loadUnload} event completed for the following client " +
                        $"identifiers:({sceneEvent.ClientsThatCompleted})");
                    if (sceneEvent.ClientsThatTimedOut.Count > 0)
                    {
                        Debug.LogWarning($"{loadUnload} event timed out for the following client " +
                            $"identifiers:({sceneEvent.ClientsThatTimedOut})");
                    }
                    break;
                }
        }
    }

    public void UnloadScene()
    {
        // Assure only the server calls this when the NetworkObject is
        // spawned and the scene is loaded.
        if (!IsServer || !IsSpawned || !m_LoadedScene.IsValid() || !m_LoadedScene.isLoaded)
        {
            return;
        }

        // Unload the scene
        var status = NetworkManager.SceneManager.UnloadScene(m_LoadedScene);
        CheckStatus(status, false);
    }
    public void switcherBtnFunc()
    {
        UnloadScene();
        //NetworkManager.SceneManager.OnSceneEvent += SceneManager_OnSceneEvent;
        var status = NetworkManager.SceneManager.LoadScene("playerLobby", LoadSceneMode.Additive);
        CheckStatus(status);
    }
}
