using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thisMiniGameScript : MonoBehaviour
{

    public static thisMiniGameScript instance;

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
        //checks if the time to submit the face has reached a threshold
        if (cTimeToSumbit >= timeToSubmit)
        {
            canSpawnFace = true;
        }
        //if threshold is not reached, increment the value of time to submit 
        else
        {
            cTimeToSumbit += Time.deltaTime;
        }
        
    }

    IEnumerator addTimer()
    {
        //Debug.Log("current time: " + cTimeToSpawn);
        //checks if the current time until face spawn has reached a threshold
        if (cTimeToSpawn >= timeToSpawn)
        {
            //if it has reached a threshold
            //set the time to spawn back to 0
            cTimeToSpawn = 0;
            //call the spawn face method
            spawnFace();
            //ensure that the face cannot be spawned again 
            canSpawnFace = false;
        }
        //if the threshold has not been reached
        else 
        {
            //and a face can be spawned
            if (canSpawnFace)
            {
                //increment cTimeToSpawn
                cTimeToSpawn += Time.deltaTime;
            }
        }
        yield return null;
    }
    //array of game objects for the faces
    public GameObject[] faces;
    bool canSpawnFace = true;
    public bool CanSpawnFace
    { 
        get { return canSpawnFace; }
        set { canSpawnFace = value; }
    }

    private GameObject currentFace;
    public GameObject CurrentFace { get { return currentFace; }}
    //method to spawn face object

    [SerializeField] private Vector2 facePosition;
    
    //method responsible for spawning faces
    public void spawnFace()
    {
        //current face game object is assigned a new (random) game object taken from the faces array
        currentFace = faces[Random.Range(0, faces.Length)];
        //place the current face into the scene
        Instantiate(currentFace, facePosition, Quaternion.identity);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        cTimeToSpawn = 0;
        timeToSpawn = 3;
    }

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"can spawn face: {canSpawnFace}");
        StartCoroutine(addTimer());
        playerCountScript.instance.checkPlayerCount();
        addPlayer();
        
    }

    public void addPlayer()
    {
        Instantiate(player, Vector2.zero, Quaternion.identity);
    }

}
