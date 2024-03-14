using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
public class PlatformCamera : NetworkBehaviour
{
    public Transform attachedPlayer;
    public Transform camTarget;
    public Transform camTrans;
    public GameObject Player;
    private bool isNetwork = false;
    private Camera thisCamera;
    // Use this for initialization
    public override void OnNetworkSpawn()
    {
        camTrans = Camera.main.GetComponent<Transform>();
        Player = GameObject.FindWithTag("Player");
        camTarget = Player.GetComponent<Transform>();
        isNetwork = true;

    }
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        //camTrans = Camera.main.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isNetwork == true)
        {
            //camTrans.position = camTarget.position;
            Vector3 player = camTarget.transform.position;
            Vector3 newCamPos = new Vector3(player.x, player.y, camTrans.transform.position.z);
            camTrans.transform.position = newCamPos;
        }
        else
        {
            Vector3 player = attachedPlayer.transform.position;
            Vector3 newCamPos = new Vector3(player.x, player.y, transform.position.z);
            transform.position = newCamPos;
        }
        
    }
}
