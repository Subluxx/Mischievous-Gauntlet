using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowObject : MonoBehaviour
{
    public bool canBePressed;
    public AudioSource successSparkle;
    public AudioSource failedSparkle;


    public KeyCode keyToPress;

    public float beatTempo;

    public bool hasStarted;
    public Animator animator;

    public ButtonController buttonController;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = 120 / 120f;
        hasStarted = true;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }






        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {

                buttonController.comboScore += 1;
                Debug.Log(buttonController.comboScore);
                animator.SetTrigger("Pop");
                StartCoroutine(popArrow(3));
                successSparkle.Play();
            }
        }

        if (transform.position.y < -2)
        {
            /*Destroy(gameObject);*/
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
        }
    }

    IEnumerator popArrow(int secs)
    {
        yield return new WaitForSeconds(secs);
        /*gameObject.SetActive(false);*/
    }
}