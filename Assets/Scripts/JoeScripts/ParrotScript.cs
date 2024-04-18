using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class ParrotScript : NetworkBehaviour
{
    [SerializeField] public float destroyDelay = 10.0f;
    [SerializeField] public float flightSpeedForce = 20f;
    //public GameObject deathsoundObject;
    //public ParticleSystem deathFeathers;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject deathsound = Instantiate(deathsoundObject);
        //deathsound.GetComponent<AudioSource>().Play();
        //ParticleSystem deathfeather = Instantiate(deathFeathers);
        ///deathfeather.GetComponent<ParticleSystem>().Play();
        //Destroy(gameObject);
        GetComponent<NetworkObject>().Despawn();
    }
    public override void OnNetworkSpawn()
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
        // Destroy(gameObject);
        GetComponent<NetworkObject>().Despawn();
    }
}
