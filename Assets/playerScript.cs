using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class for the player
public class playerScript : MonoBehaviour
{
    //int member for amount of points a player has
    int playerPoints;

    //method to set the player points to an int value
    public void setPlayerPoints(int i)
    { 
        playerPoints = i;
    }

    //method to increment player points by a value (value can be negative (duh!))
    public void changePlayerPoints(int i)
    {
        playerPoints += i;
    }


}
