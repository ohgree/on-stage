using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
    private string gameVersion = "1";

    public Text connectionInfoText;
    public Button CreateRoomButton, EnterRoomButton;
    public Text RoomName, RoomPasswd;

    public Transform RoomContent;
    public GameObject RoomEntityPrefeb;

    public Dictionary<string, GameObject> Rooms = new Dictionary<string, GameObject>();

    void Start() {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        CreateRoomButton.interactable = false;
        EnterRoomButton.interactable = false;

        connectionInfoText.text = "making connection to server";
    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby();

        CreateRoomButton.interactable = true;
        EnterRoomButton.interactable = true;
        connectionInfoText.text = "online";
    }

    public override void OnDisconnected(DisconnectCause cause) {
        CreateRoomButton.interactable = false;
        EnterRoomButton.interactable = false;
        connectionInfoText.text = "offline";

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinedLobby() {
        Rooms.Clear();
    }

    public override void OnLeftLobby() {
        Rooms.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList) {
        GameObject tempRoom = null;

        for(int i = 0; i < roomList.Count; i++) {
            RoomInfo room = roomList[i];

            if(room.RemovedFromList) { // deleted room
                Rooms.TryGetValue(room.Name, out tempRoom);
                Destroy(tempRoom);
                Rooms.Remove(room.Name);
                Debug.Log("aa");
            }
            else if(Rooms.ContainsKey(room.Name) == false) { // new room
                tempRoom = Instantiate<GameObject>(RoomEntityPrefeb, Vector3.zero, Quaternion.identity, RoomContent);
                
                tempRoom.transform.GetChild(0).gameObject.GetComponent<Text>().text = room.Name.Split('_')[0];

                Rooms[room.Name.Split('_')[0]] = tempRoom;
            }
        }
    }

    public void CreateRoom() {
        string roomName = RoomName.text + "_" + RoomPasswd.text;

        if(roomName[0] == '_') {
            Debug.Log("input room name");
            return;
        }
        else if(Rooms.ContainsKey(RoomName.text)) {
            Debug.Log("Room already exists");
            return;
        }

        PhotonNetwork.CreateRoom(roomName, new RoomOptions{MaxPlayers=10}, null);

        Debug.Log("enter room " + roomName);
    }
    public override void OnJoinedRoom() {
        Debug.Log("Room Joined");
        SceneManager.LoadScene("Auditorium");
    }
}
