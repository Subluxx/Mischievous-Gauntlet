using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Unity.Netcode;
public class SeaGullScript : NetworkBehaviour
{
    [SerializeField] public float destroyDelay = 10.0f;
    public GameObject deathsoundObject;
    public ParticleSystem deathFeathers;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject deathsound = Instantiate(deathsoundObject);
        deathsound.GetComponent<AudioSource>().Play();
        ParticleSystem deathfeather = Instantiate(deathFeathers);
        deathfeather.GetComponent<ParticleSystem>().Play();
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
