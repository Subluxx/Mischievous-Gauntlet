using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

//main manager class
public class mainManager : MonoBehaviour
{
    

    //string list member to store the names of each minigame scene in the game.
    string[] gameSceneNames = {"testScene1", "testScene2"};



    //method to load the game
    public void loadGame() 
    {
        //random scene is loaded in, using a random index for the gameSceneNames string array
        SceneManager.LoadScene(gameSceneNames[Random.Range(0, gameSceneNames.Length)]);
    }
}
