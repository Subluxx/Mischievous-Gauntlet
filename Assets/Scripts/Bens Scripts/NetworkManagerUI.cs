using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    //[SerializeField] private Button serverBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private Button hostBtn;

    private void Awake() {
        //serverBtn.onClick.AddListener(() =>
        //{
        //    NetworkManager.Singleton.StartServer();
        //    foreach (Transform child in gameObject.transform)
        //    {
        //        child.gameObject.SetActive(false);
        //    }
        //});
        clientBtn.onClick.AddListener(() => {
            //NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
            NetworkManager.Singleton.StartClient();
            foreach (Transform child in gameObject.transform) {
                child.gameObject.SetActive(false);
            }
        });
        hostBtn.onClick.AddListener(() => {
            //NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
            NetworkManager.Singleton.StartHost();
            foreach (Transform child in gameObject.transform) {
                child.gameObject.SetActive(false);
            }
        });
    }
}
