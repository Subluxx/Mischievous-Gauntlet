using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public int comboScore;

    public KeyCode keyToPress;

/*    public OnScreenMessages onScreenMessages;
*/    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        comboScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            Debug.Log("tap");
            theSR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }


        if (comboScore >= 5)
        {
            Debug.Log("New move!");
/*            onScreenMessages.newMovesBool = true;
*/            comboScore = 0;
        }
    }
}