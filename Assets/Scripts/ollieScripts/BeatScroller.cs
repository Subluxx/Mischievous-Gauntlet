using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeatScroller : MonoBehaviour
{

    public GameObject UpArrowPrefab;
    public GameObject DownArrowPrefab;
    public GameObject RightArrowPrefab;
    public GameObject LeftArrowPrefab;

    public float x;
    public float y;
    public float z;

    public float spawnCounter;
    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter++;



        if (spawnCounter > 100)
        {

            CreateArrow();

            spawnCounter = 0;
        }

    }

    public void CreateArrow()
    {
        float randomNumber = Random.Range(0, 4);
        if (randomNumber == 0)
        {
/*            UpArrowPrefab.GetComponent<ArrowObject>().enabled = true;
*/            Instantiate(UpArrowPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
        else if (randomNumber == 1)
        {
/*            DownArrowPrefab.GetComponent<ArrowObject>().enabled = true;
*/            Instantiate(DownArrowPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
        else if (randomNumber == 2)
        {
/*            LeftArrowPrefab.GetComponent<ArrowObject>().enabled = true;
*/            Instantiate(LeftArrowPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
        else if (randomNumber == 3)
        {
/*            RightArrowPrefab.GetComponent<ArrowObject>().enabled = true;
*/            Instantiate(RightArrowPrefab, new Vector3(x, y, z), Quaternion.identity);
        }

    }
}