using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    void Start() {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions {MaxPlayers=20}, null);
    }

    public override void OnJoinedRoom() {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 5, 10), Quaternion.identity);
    }

    public void Disconnect() {
        PhotonNetwork.Disconnect();
    }

    void Update() {
        //
    }
}
