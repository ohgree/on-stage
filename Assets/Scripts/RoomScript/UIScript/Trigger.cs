using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Trigger : MonoBehaviour
{
    public Button UploadButton;
    public void Start(){
        UploadButton.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other) {
        if(PhotonNetwork.IsMasterClient){         
            UploadButton.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other) {
        UploadButton.gameObject.SetActive(false);
    }
}
