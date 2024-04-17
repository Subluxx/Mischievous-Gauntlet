using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerScript : NetworkBehaviour
{

    public CannonScript Cannon;
    Vector2 mousePosition;
    Rigidbody2D rb;

    public override void OnNetworkSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            Cannon.Fire();
        }
    }
    private void FixedUpdate()
    {
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        if(aimAngle < 30 && aimAngle > -30)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, aimAngle);
        }
    }
}
