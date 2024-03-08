using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movingThingScript : MonoBehaviour
{
    Vector3 spawnPosition;
    Vector3 toMove;
    [SerializeField] public float scrollspeed = 0.01f;
    [SerializeField] public float boundingArea = 1f;
    public bool ymovingup = true;
    // Start is called before the first frame update
    void Start()
    {
        toMove = transform.position;
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        toMove.x += scrollspeed;

        if (toMove.y > spawnPosition.y + boundingArea)
        {
            ymovingup = true;
        }
        else if (toMove.y < spawnPosition.y - boundingArea * 2)
        {
            ymovingup = false;
        }
        if (!ymovingup)
        {
            toMove.y += scrollspeed;
        }
        else
        {
            toMove.y -= scrollspeed;
        }


        transform.position = toMove;
    }
}
