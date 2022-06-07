using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerName : MonoBehaviourPun
{
    PhotonView PV;
    GameObject CurrentCamera;
    public TextMesh Name;
    
    void Start() {
        PV = photonView;
        CurrentCamera = GameObject.FindGameObjectWithTag("MainCamera");

        if(PV.IsMine) {
            Name.color = Color.white;
        }
    } 

    void Update() {
        this.transform.rotation = CurrentCamera.transform.rotation;
        
    }
}
