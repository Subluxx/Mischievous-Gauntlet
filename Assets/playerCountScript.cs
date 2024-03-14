using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCountScript : MonoBehaviour
{
    public static playerCountScript instance;
    //bool member -> condition for if the script should check the player count or not
    bool startCheck;

    public void setStartCheck()
    { 
        startCheck = true;
    }

    private void Awake()
    {
        instance = this;
    }

    //int var to keep track of current players in the game
    int currentPlayerCount;

    //method to add to the player count
    public void addPlayerCount(int i)
    {
        currentPlayerCount += i;
        startCheck = true;
    }

    //method to subtract from the playercount
    public void subPlayerCount(int i)
    { 
        currentPlayerCount -= i;
    }

    

    //method to check if a player count has reached a certain threshold
    public void checkPlayerCount()
    {
        if (startCheck == true)
        {
            if (currentPlayerCount == 0)
            {
                miniGameManager2.setHasEnded();
            }
        }
        
    }

    private void Start()
    {
        startCheck = false;
        //upon start -> set the current player count to 0
        currentPlayerCount = 0;
        Debug.Log($"player count : {currentPlayerCount}");
        
    }

    private void Update()
    {
        //Debug.Log($"player count : {currentPlayerCount}");
    }


}
