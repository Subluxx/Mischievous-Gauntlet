using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
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

    IEnumerator RemoveProjectile(float delayVar)
    {
        yield return new WaitForSeconds(delayVar);
        Destroy(gameObject);
    }
}
