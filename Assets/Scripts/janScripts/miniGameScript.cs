using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniGameScript : MonoBehaviour
{

    public static miniGameScript instance;

    private void Awake()
    {
        instance = this;
    }

    float cTimeToSpawn;
    float timeToSpawn;


    float cTimeToSumbit = 0;
    float timeToSubmit = 3;

    void submitTimer()
    {
        //Debug.Log("Time to submit: " + cTimeToSumbit);
        if (cTimeToSumbit >= timeToSubmit)
        {
            canSpawnFace = true;
        }
        else
        {
            cTimeToSumbit += Time.deltaTime;
        }
        
    }

    IEnumerator addTimer()
    {
        //Debug.Log("current time: " + cTimeToSpawn);

        if (cTimeToSpawn >= timeToSpawn)
        {
            cTimeToSpawn = 0;
            spawnFace();
            canSpawnFace = false;
        }
        else 
        {
            if (canSpawnFace)
            {
                cTimeToSpawn += Time.deltaTime;
            }
        }
        yield return null;
    }
    public GameObject face;
    bool canSpawnFace = true;
    public bool CanSpawnFace
    { 
        get { return canSpawnFace; }
        set { canSpawnFace = value; }
    }

    //method to spawn face object
    public void spawnFace()
    {
        Instantiate(face);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        cTimeToSpawn = 0;
        timeToSpawn = 3;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(addTimer());
    }


}
