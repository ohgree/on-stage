using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class NetworkManager : MonoBehaviourPunCallbacks {
  public CinemachineVirtualCameraBase cam;
  public GameObject publicData;

  void Start() {
    publicData = GameObject.FindGameObjectWithTag("PublicData");

    PhotonNetwork.JoinOrCreateRoom(publicData.GetComponent<PublicData>().roomName, new RoomOptions { MaxPlayers = 20 }, null);
  }

  public override void OnJoinedRoom() {
    GameObject player = PhotonNetwork.Instantiate("Player", new Vector3(0, 1, 10), Quaternion.identity);

    cam.LookAt = cam.Follow = player.transform;
    player.GetComponentInChildren<TextMesh>().text = publicData.GetComponent<PublicData>().playerName;
  }

  public void Disconnect() {
    PhotonNetwork.LeaveRoom();
    SceneManager.LoadScene("Lobby");
  }

  void Update() {
    //
  }
}
