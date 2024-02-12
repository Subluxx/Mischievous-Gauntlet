using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class for the mini game manager
public class miniGManager : MonoBehaviour
{
    //bool member to check if the minigame has ended. 
    private bool hasEnded;
    public bool HasEnded
    { 
        get { return hasEnded; }
        set { hasEnded = value; }
    }

    public GameObject mainMgr;
    private mainManager m;

    private void Start()
    {
        m = mainMgr.GetComponent<mainManager>();
        hasEnded = false;
    }

    private void Update()
    {
        checkEnd();
    }

    //method to check if hasEnded is true
    void checkEnd() 
    {
        if (hasEnded == true)
        {
            m.loadGame(); 
        }
    }

    //method to change the value of hasEnded to true
    public void setHasEnded()
    { 
        hasEnded = true;
    }
}
