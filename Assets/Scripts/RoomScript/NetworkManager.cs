using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    void Start() {
        //
    }

    public override void OnJoinedRoom() {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 5, 10), Quaternion.identity);
    }

    public void Disconnect() {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Lobby");
    }

    void Update() {
        //
    }
}
