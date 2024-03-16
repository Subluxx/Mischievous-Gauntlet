using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishCollect : MonoBehaviour    
{
    private UnityEngine.Object explosionRef;
    // Start is called before the first frame update
   private void Start()
    {
        explosionRef = Resources.Load("Explosion");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
            Destroy(gameObject);


       }

    }
}

