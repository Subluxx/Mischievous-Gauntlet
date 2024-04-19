using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.Netcode;
using System;
using UnityEngine.SceneManagement;

public static class newManager
{
    public static string[] gameSceneNames = { "playerLobby", "joeScene", "benScene" , "janScene", "ollieScene"};
    public static List<string> currentGameSceneOrder = new List<string>();
    public static string _scene;

    public static int index =-1;

    public static void addScenesToGame()
    {
        foreach (string s in gameSceneNames)
        { 
            currentGameSceneOrder.Add(s);
        }
    }


    public static void debug1()
    {
        for (int i = 0; i < currentGameSceneOrder.Count; i++)
        {
            //Debug.Log($"element {i} is {currentGameSceneOrder[i]}");
        }
    }

    public static string loadGame()
    {
        //if the index number in the new manager is less than the max number of scenes
        if (newManager.index < currentGameSceneOrder.Count)
        {
            //var status = new NetworkManager.SceneManager.LoadScene(currentGameSceneOrder[index], LoadSceneMode.Single);
            //int placeHolder = index;
            _scene = currentGameSceneOrder[index];
            Debug.Log(index);
            return _scene;
            //SceneManager.LoadScene(currentGameSceneOrder[index]);
        }
        //if all minigames have been played -> load the game over scene
        else 
        {
            return "endScene";
           // loadEndScene();
        }
        
        //increment index
    }

    //a method to load in the scene that is supposed to appear when all the minigames have been played
    public static void loadEndScene()
    {
        SceneManager.LoadScene("endScene");
    }
}
