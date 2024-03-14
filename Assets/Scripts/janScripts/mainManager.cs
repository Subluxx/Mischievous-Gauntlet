using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Linq;
>>>>>>> origin/janBranch
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

//main manager class
public class mainManager : MonoBehaviour
{
    
<<<<<<< HEAD

    //string list member to store the names of each minigame scene in the game.
    string[] gameSceneNames = {"testScene1", "testScene2"};



    //method to load the game
    public void loadGame() 
    {
        //random scene is loaded in, using a random index for the gameSceneNames string array
        SceneManager.LoadScene(gameSceneNames[Random.Range(0, gameSceneNames.Length)]);
    }
=======
    public static mainManager instance;

    private void Awake()
    {
        instance = this;
    }



    //string list member to store the names of each minigame scene in the game.
    string[] gameSceneNames = {"testScene1", "testScene2", "testScene3"};
    
    //Dictionary<string, bool> gameSceneDict = new Dictionary<string, bool>() { {"testScene1", false}, {"testScene2", false}, {"testScene3", false } };

    private void Start()
    {
        
    }

    private void Update()
    {
        
        
    }

    

    

    

    
>>>>>>> origin/janBranch
}
