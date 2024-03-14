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

    public PlayerController player;
    public DistanceScript distanceText;

    private string playerText = "";

    [SerializeField] public float destroyDelay = 10.0f;

    public ButtonController buttonController;
    void Start()
    {
        beatTempo = 120 / 120f;
        hasStarted = true;

        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (transform.position.y < -5)
        {

            /*StartCoroutine(popArrow(1));*/
        }

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
                player.distance += 100;
                playerText = player.distance.ToString() + " m";
                distanceText.displayText = playerText;

                buttonController.comboScore += 1;
                Debug.Log(buttonController.comboScore);
                animator.SetTrigger("Pop");
                
                successSparkle.Play();

                StartCoroutine(popArrow(0.5f));
                beatTempo = 0;
            }
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

    IEnumerator popArrow(float secs)
    {
        yield return new WaitForSeconds(secs);
        Destroy(gameObject);

    }
}