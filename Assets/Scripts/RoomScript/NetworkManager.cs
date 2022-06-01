using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class NetworkManager : MonoBehaviourPunCallbacks {
  public CinemachineFreeLook cam;
  void Start() {
    PhotonNetwork.ConnectUsingSettings();
  }

  public override void OnConnectedToMaster() {
    PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 20 }, null);
  }

  public override void OnJoinedRoom() {
    GameObject player = PhotonNetwork.Instantiate("Player", new Vector3(0, 1, 10), Quaternion.identity);
    cam.LookAt = cam.Follow = player.transform;
  }

  public void Disconnect() {
    PhotonNetwork.Disconnect();
  }

  void Update() {
    //
  }
}
