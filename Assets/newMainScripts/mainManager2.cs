using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainManager2 : MonoBehaviour
{
    // Start is called before the first frame update
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
        newManager.loadGame();
    }
}
