using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public static class newManager
{
    public static string[] gameSceneNames = { "playerLobby", "janScene" , "joeScene", "ollieScene", "benScene"};
    public static List<string> currentGameSceneOrder = new List<string>();

    public static int index;

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

    public static void loadGame()
    {
        //if the index number in the new manager is less than the max number of scenes
        if (newManager.index < currentGameSceneOrder.Count)
        {
            //SceneManager.LoadScene(currentGameSceneOrder[index]);
            //NetworkManager.SceneManager.LoadScene(currentGameSceneOrder[index], LoadSceneMode.Additive);
        }
        //if all minigames have been played -> load the game over scene
        else 
        {
            loadEndScene();
        }
        
        //increment index
        index++;
    }

    //a method to load in the scene that is supposed to appear when all the minigames have been played
    public static void loadEndScene()
    {
        SceneManager.LoadScene("endScene");
    }
}
