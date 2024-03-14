using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class for the mini game manager
public static class miniGManager
{
    
    

    //bool member to check if the minigame has ended. 
    public static bool hasEnded;
    

  

    

    //method to check if hasEnded is true
    public static void checkEnd() 
    {
        if (hasEnded == true)
        {
            //m.loadGame();
            newManager.loadGame();
        }
    }

    //method to change the value of hasEnded to true
    public static void setHasEnded()
    { 
        hasEnded = true;
    }
}
