using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerScript : MonoBehaviour
{

    public CannonScript cannon;
    public Vector2 mousePosition;
    public Rigidbody2D rb;
    private Camera _camera;
    private bool _isCameraNotNull;

    private void Start()
    {
        _isCameraNotNull = _camera != null;
        _camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
            mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            cannon.Fire();
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
