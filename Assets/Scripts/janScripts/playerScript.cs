using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//class for the player
public class playerScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Sumbit!!");
        }
    }
}
