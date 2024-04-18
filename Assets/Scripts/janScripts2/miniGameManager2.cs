using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.mainManager2;
public static class miniGameManager2 
{
    public static bool hasEnded;
    public static MainManager2 mainmanager2;
    public static void checkEnd()
    {
        if (hasEnded == true)
        {
            mainmanager2 = GameObject.FindObjectOfType<MainManager2>();
            //mainmanager2.GetComponent<MainManager2>().loadGame();
            mainmanager2.loadGame();
        }
    }

    public static void setHasEnded()
    { 
        hasEnded = true;
    }
}