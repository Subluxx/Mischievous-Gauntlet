using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlatformCreation : NetworkBehaviour {
    private float[] platformWidths;
    private float platformHeight;
    private float distanceBetween;
    private float previousPosition;
    public Transform endPoint;
    [SerializeField] private float distanceBetweenMin;
    [SerializeField] private float distanceBetweenMax;
    public GameObject[] Platforms;
    private int platformSelector; 
    void Start() {
        previousPosition = transform.position.x;
        platformWidths = new float[Platforms.Length];
        for(int i =0; i<Platforms.Length; i++) {
            platformWidths[i] = Platforms[i].GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update() {
        if(transform.position.x < endPoint.position.x) {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            transform.position = new Vector3(previousPosition + platformWidths[platformSelector] + distanceBetween, 0, 0);
            platformSelector = Random.Range(0, Platforms.Length);
            //transform.position = new Vector3(transform.position.x+platformWidth+distanceBetween,)
            previousPosition = transform.position.x;
        }
    }
}
