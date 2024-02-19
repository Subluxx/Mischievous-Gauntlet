using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    //Animator anim; //if there was an animation for movement this would be used but since there is none there is nothing being called but the movement still works

   
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>(); //if there was an animation for movement this would be used but since there is none there is nothing being called but the movement still works
    }
    void FixedUpdate()
    {
        float speed = 4.0f;
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"),
       Input.GetAxis("Vertical")) * speed;
    }
    // Update is called once per frame
    void Update()
    {
        /*
        anim.SetFloat("xspeed", rb.velocity.x); //if there was an animation for movement this would be used but since there is none there is nothing being called but the movement still works
        anim.SetFloat("yspeed", rb.velocity.y); //if there was an animation for movement this would be used but since there is none there is nothing being called but the movement still works
        if (rb.velocity.magnitude < 0.01)
        {
            anim.speed = 0.0f; //if there was an animation for movement this would be used but since there is none there is nothing being called but the movement still works
        }
        else
        {
            anim.speed = 1.0f; //if there was an animation for movement this would be used but since there is none there is nothing being called but the movement still works
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        {
            /*if (other.gameObject.tag == "Fish")
                {
                ScoreManager.scoreCount += 1;
                } */
        }
    }

}
