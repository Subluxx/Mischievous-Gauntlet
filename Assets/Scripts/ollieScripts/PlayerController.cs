using System.Collections;
using System.Collections.Generic;
//using Unity.Burst.CompilerServices;
using UnityEngine;
public class PlayerController : MonoBehaviour

{
    Rigidbody2D rigidBody;
    public AudioSource HeartPick;

    public AudioSource Walking;
    public float speed = 4.0f;
    public float default_speed = 4.0f;
    public float running_speed = 6.0f;
    public float jumpForce = 8.0f;
    public float airControlForce = 10.0f;
    public float airControlMax = 1.5f;
    public bool isMoving = false;
    Vector2 boxExtents;
/*    Animator animator;
*/
    float inputHorizontal;
    float inputVertical;



    // Use this for initialization
    void Start()
    {
        boxExtents = GetComponent<BoxCollider2D>().bounds.extents;
        rigidBody = GetComponent<Rigidbody2D>();
/*        animator = GetComponent<Animator>();
*/    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Mathf.Abs(rigidBody.velocity.x);
/*        animator.SetFloat("xspeed", xSpeed);
*/
        float ySpeed = Mathf.Abs(rigidBody.velocity.y);
/*        animator.SetFloat("yspeed", ySpeed);
*/    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        // check if we are on the ground
        Vector2 bottom = new Vector2(transform.position.x, transform.position.y - boxExtents.y);

        Vector2 hitBoxSize = new Vector2(boxExtents.x * 2.0f, 0.05f);

        RaycastHit2D result = Physics2D.BoxCast(bottom, hitBoxSize, 0.0f,
        new Vector3(0.0f, -1.0f), 0.0f, 1 << LayerMask.NameToLayer("Ground"));

        bool grounded = result.collider != null && result.normal.y > 0.9f;
        if (grounded)
        {
            if (Input.GetAxis("Jump") > 0.0f)
                rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            else
                rigidBody.velocity = new Vector2(speed * h, rigidBody.velocity.y);
        }




        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (inputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            isMoving = true;

        }

        if (inputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            isMoving = true;

        }

        if (isMoving == true)
        {
            Walking.Play();

        }


        if (Input.GetKey(KeyCode.LeftShift) & isMoving == true)
        {
            speed = running_speed;
/*            animator.SetTrigger("Running");
*/        }
        else
        {
            speed = default_speed;
        }


    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Heart")
        {
            HeartPick.Play();
            Destroy(coll.gameObject);

        }
    }
}