using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotScript : MonoBehaviour
{
    [SerializeField] public float destroyDelay = 10.0f;
    [SerializeField] public float flightSpeedForce = 20f;
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
