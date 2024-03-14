using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//class for the player
public class playerScript : MonoBehaviour
{
    protected string playerFace;
    protected Sprite faceSprite;
    public Sprite[] faceSprites;

    private bool spfInvoked = false;
    private void setPlayerFace(string s)
    {
        if (spfInvoked == false) { playerFace = s; spfInvoked = true;
            switch (playerFace)
            {
                case "happy":
                    faceSprite = faceSprites[0];
                    break;
                case "neutral":
                    faceSprite = faceSprites[1];
                    break;
                case "sad":
                    faceSprite = faceSprites[2];
                    break;
            }
        }
    }

    thisMiniGameScript t;

    private void Start()
    {
        t = thisMiniGameScript.instance;
        //when a player prefab is instantiated -> increment the value of the variable keeping track of the player number in the minigame
        playerCountScript.instance.addPlayerCount(1);
        
    }

    private void Update()
    {
        playerFaceChange();
        detectSubmission();

        //Debug.Log($"Player can submit: {canSubmit}");
        //Debug.Log("player face is: " + playerFace);
    }

    //method responsible for changing the type of face the player possesses in a moment 
    private void playerFaceChange()
    {
        //if a face can be spawned
        if (t.CanSpawnFace == false)
        {
            //set the player face to a random face
            setPlayerFace(t.faces[Random.Range(0, t.faces.Length)].GetComponent<secondaryFaceScript>().FaceType);
            //display the given face to the player
            displayPlayerFace();
        }
        //if a face cannot be spawned
        else
        {
            //remove the player face from the scene
            removePlayerFace();
            //set the player face to a null value
            setPlayerFace("");
            //set spf invoked to false again
            spfInvoked = false;
        }
    }

    //bool member responsible for determining whether or not the player can submit their face
    bool canSubmit = true;

    
    private void submit()
    {
        
        //checks if the player can submit a face
        if (canSubmit == true)
        {
            Debug.Log("Submit");
            //check if the player face and the current face are of the same type
            if (playerFace == t.CurrentFace.GetComponent<secondaryFaceScript>().FaceType)
            {
                //submission is correct
                Debug.Log("correct submission");
            }
            //if player face and current face are not the same
            else 
            {
                //submission is incorrect
                Debug.Log("incorrect submission");
                //subtract the number of players currently in the minigame.
                playerCountScript.instance.subPlayerCount(1);
                //render the player unable to submit their face again.
                canSubmit = false;
            }
        }
        else { Debug.Log("The player cannot submit anymore!!!"); }
        
    }

    private void detectSubmission()
    {
        //if the player presses space and the face is present in the scene
        if (Input.GetKeyDown(KeyCode.Space) && thisMiniGameScript.instance.CanSpawnFace == false)
        {
            //call the submit method
            submit();
        }
    }

    [SerializeField] private GameObject playerFaceSprite;

    //method that manages the display of the player face
    private void displayPlayerFace()
    {
        //display the face
        playerFaceSprite.GetComponent<SpriteRenderer>().enabled = true;
        //change the colour of the face accordingly
        playerFaceSprite.GetComponent<SpriteRenderer>().sprite= faceSprite;
    }

    //method that manages the removal of the player face gameobject
    private void removePlayerFace()
    {
        playerFaceSprite.GetComponent<SpriteRenderer>().enabled = false;
    }

}
