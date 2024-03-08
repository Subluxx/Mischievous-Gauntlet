using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
public class PlatformCamera : NetworkBehaviour
{
    public Transform attachedPlayer;
    Camera thisCamera;
    // Use this for initialization
    void Start()
    {
        thisCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player = attachedPlayer.transform.position;
        Vector3 newCamPos = new Vector3(player.x, player.y, transform.position.z);
        transform.position = newCamPos;
    }
}
