using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//class responsible for the duration of the minigame
public class durationMgr : MonoBehaviour
{
    //float member for the duration of the game
    [SerializeField] private float miniGameDuration;
    float currentDuration;

    public GameObject miniGManager;
    private miniGManager m;

    private void Start()
    {
        m = miniGManager.GetComponent<miniGManager>();

        currentDuration = 0;
        setDuration(10);
    }

    private void Update()
    {
        Debug.Log(m.HasEnded);
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
        Debug.Log(currentDuration);
        //current duration is incremented
        currentDuration += Time.deltaTime;
        //check if the current duration has reached the miniGameDuration
        if (currentDuration > miniGameDuration)
        {
            m.setHasEnded();
        }
        yield return null;
    }
}
