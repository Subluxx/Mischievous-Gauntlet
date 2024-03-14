using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class miniGameManager2 
{
    public static bool hasEnded;

    public static void checkEnd()
    {
        if (hasEnded == true)
        {
            newManager.loadGame();
        }
    }

    public static void setHasEnded()
    { 
        hasEnded = true;
    }
}
