using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SeaGullScript : MonoBehaviour
{
    public float destroyDelay = 10.0f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

    }
    private void Awake()
    {
        StartCoroutine(RemoveProjectile(destroyDelay));
    }
    private void Update()
    {
        RemoveProjectile(destroyDelay);
    }
    

    IEnumerator RemoveProjectile(float delayVar)
    {
        yield return new WaitForSeconds(delayVar);
        Destroy(gameObject);
    }

}
