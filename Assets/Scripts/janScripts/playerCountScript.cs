using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCountScript : MonoBehaviour
{
    //int member to keep track of player count.
    int playerCount;

    //method to add to the player count
    public void addPlayerCount(int i)
    {
        playerCount += i;
    }

    //method to subtract from the playercount
    public void subPlayerCount(int i)
    { 
        playerCount -= i;
    }

    public GameObject miniGManager;
    private miniGManager m;

    //method to check if a player count has reached a certain threshold
    public void checkPlayerCount(int i)
    {
        if (playerCount <= i)
        {
            //do something
            m.setHasEnded();
        }
    }

    private void Start()
    {
        m = miniGManager.GetComponent<miniGManager>();
        
    }

    private void Update()
    {
        Debug.Log("player count: " + playerCount);
        checkPlayerCount(0);
    }


}
