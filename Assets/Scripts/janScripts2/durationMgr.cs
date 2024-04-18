using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//class responsible for the duration of the minigame
public class durationMgr : MonoBehaviour
{
    //float member for the duration of the game
    [SerializeField] private float miniGameDuration;
    public MainManager2 mainmanager2;
    float currentDuration;

    //public GameObject manager;

    private void Start()
    {
        miniGameManager2.hasEnded = false;
        currentDuration = 0;
        setDuration(miniGameDuration);
    }

    private void Update()
    {
        miniGameManager2.checkEnd();
        //Debug.Log(m.HasEnded);
        StartCoroutine(countUp());
    }

    //method to set the duration of the minigame
    void setDuration(float dur)
    { 
        miniGameDuration = dur;
    }

    //coroutine responsible for minigame time counter
    IEnumerator countUp()
    {
        //Debug.Log(currentDuration);
        //current duration is incremented
        currentDuration += Time.deltaTime;
        //check if the current duration has reached the miniGameDuration
        if (currentDuration > miniGameDuration)
        {
            mainmanager2.loadGame();

        }
        yield return null;
    }
}
