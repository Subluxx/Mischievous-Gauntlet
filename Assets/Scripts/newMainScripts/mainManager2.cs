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
    //public string m_SceneName;
    //private Scene m_LoadedScene;
    //[SerializeField] private Button switcherBtn;
    private string currentScene;
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
        currentScene = newManager.loadGame();
        NetworkManager.SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
    }
    public override void OnNetworkSpawn()
    {
        //if (IsServer && !string.IsNullOrEmpty(m_SceneName))
        //{
        //    //NetworkManager.SceneManager.OnSceneEvent += SceneManager_OnSceneEvent;
        //    loadGame();
        //    //var status = NetworkManager.SceneManager.LoadScene(m_SceneName, LoadSceneMode.Single);
        //}

        //base.OnNetworkSpawn();
        loadGame();

    }
}
