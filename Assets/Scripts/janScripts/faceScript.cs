using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceScript : MonoBehaviour
{
    float timeToDestroy;
    float currentTime;
    IEnumerator addTimer()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeToDestroy)
        {
            Destroy(this.gameObject);
        }
        yield return null;
    }

    private void Start()
    {
        currentTime = 0;
        timeToDestroy = 2;
    }

    private void Update()
    {
        Debug.Log("Face timer: " + currentTime);
        StartCoroutine(addTimer());
    }

    private void OnDestroy()
    {
        miniGameScript.instance.CanSpawnFace = true;
    }
}
