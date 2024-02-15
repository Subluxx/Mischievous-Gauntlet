using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    // Start is called before the first frame update

    public void Fire()
    {
        GameObject projectile = Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 180f));
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
