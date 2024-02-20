using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{


    public GameObject UpArrowPrefab;
    public GameObject DownArrowPrefab;
    public GameObject RightArrowPrefab;
    public GameObject LeftArrowPrefab;

    public float spawnCounter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter++;



        if (spawnCounter > 200)
        {
            float ypos = Random.Range(3, 7);
            float zpos = -0.08376108f;

            float xpos = -1.5f + Random.Range(0, 4);
            CreateArrow(xpos, ypos, zpos);

            xpos = 6f + Random.Range(0, 4);
            CreateArrow(xpos, ypos, zpos);

            xpos = 14f + Random.Range(0, 4);
            CreateArrow(xpos, ypos, zpos);

            spawnCounter = 0;
        }

    }

    public void CreateArrow(float x, float y, float z)
    {
        float randomNumber = Random.Range(0, 4);
        if (randomNumber == 0)
        {
            Instantiate(UpArrowPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
        else if (randomNumber == 1)
        {
            Instantiate(DownArrowPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
        else if (randomNumber == 2)
        {
            Instantiate(LeftArrowPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
        else if (randomNumber == 3)
        {
            Instantiate(RightArrowPrefab, new Vector3(x, y, z), Quaternion.identity);
        }

    }
}