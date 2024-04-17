using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CannonScript : NetworkBehaviour
{
    public GameObject ProjectilePrefab;
    public GameObject ProjectileInst { get; private set; }
    public Transform firePoint;
    public float fireForce = 20f;
    public ShakeBehaviour shakeBehaviour;
    public ParticleSystem cannonSmoke;
    public AudioSource cannonSound;
    [SerializeField] public float duration = 1f;
    [SerializeField] public float magnitude = 1f;
    bool canFire = false;
    [SerializeField] float timeAlapsed = 0f;
    [SerializeField] public float timeUntilFire = 2f;
    // Start is called before the first frame update

    private void Update()
    {
        timeAlapsed += Time.deltaTime;
        if(timeAlapsed > timeUntilFire)
        {
            canFire = true;
            timeAlapsed = 0f;
        }
    }
    public void Fire()
    {
        if (canFire)
        {
            ProjectileInst = Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 180f));
            //GameObject projectile = Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 180f));
            ProjectileInst.GetComponent<NetworkObject>().Spawn();
            ProjectileInst.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

            cannonSmoke.Play();
            cannonSound.Play();

            StartCoroutine(shakeBehaviour.Shake(duration, magnitude));

            canFire = false;
        }
    }
}
