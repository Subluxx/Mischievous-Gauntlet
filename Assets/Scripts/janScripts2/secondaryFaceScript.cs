using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//secondary face script given to specific faces in the minigame scene
public class secondaryFaceScript : faceScript
{
    // Start is called before the first frame update
    void Start()
    {
        //time to destroy is set to a number of seconds
        timeToDestroy = 2;
        //current time is set to 0
        currentTime = 0;

        //face type is set to a value (serialise field so it is given in inspector)
        setFaceType(faceType);
    }

    // Update is called once per frame
    void Update()
    {
        //start the coroutine which adds to the timer
        StartCoroutine(addTimer());

        //Debug.Log(faceType);
    }
}
