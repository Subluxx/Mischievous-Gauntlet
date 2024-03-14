using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceScript : MonoBehaviour
{
    //float variables.
    //time to destroy holds the value of the time it should take before a face is removed from a scene
    protected float timeToDestroy;
    //current time corresponds to the elapsed time of the face's presence in the scene upon instantiation
    protected float currentTime;

    //each face is given a face type variable of type string
    [SerializeField] protected string faceType;
    public string FaceType
    { 
        get { return faceType; }
        set { faceType = value; }
    }    
    //method to set the face type to a variable of choosing
    protected void setFaceType(string f)
    { 
        faceType = f;
    }

    //coroutine to add to the current time variable
    protected IEnumerator addTimer()
    {
        //if current time has reached a threshold   
        if (currentTime > timeToDestroy)
        {
            //remove this object from the scene
            Destroy(this.gameObject);
        }
        //if the timer has not reached a threshold
        else 
        {
            //increment the current time value 
            currentTime += Time.deltaTime;
        }
        yield return null;
    }

    private void Start()
    {
        /*
        currentTime = 0;
        timeToDestroy = 2;
        */
    }

    private void Update()
    {
        
    }

    //upon game object removal
    private void OnDestroy()
    {
        //tell the mini game script that another face can now be spawned again.
        thisMiniGameScript.instance.CanSpawnFace = true;
    }
}
