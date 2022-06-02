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
    public GameObject mainScript, publicData;

    public Text connectionInfoText;
    public Button CreateRoomButton, EnterRoomButton;
    public Text RoomNameCreate, RoomPasswdCreate;
    public Text RoomNameEnter, RoomPasswdEnter;

    public Transform RoomContent;
    public GameObject RoomEntityPrefeb;

    public Dictionary<string, GameObject> Rooms = new Dictionary<string, GameObject>();

    void Start() {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        CreateRoomButton.interactable = false;
        EnterRoomButton.interactable = false;

        connectionInfoText.text = "making connection to server";

        DontDestroyOnLoad(publicData);
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
            }
            else if(Rooms.ContainsKey(room.Name) == false) { // new room
                tempRoom = Instantiate<GameObject>(RoomEntityPrefeb, Vector3.zero, Quaternion.identity, RoomContent);
                
                tempRoom.transform.GetChild(0).gameObject.GetComponent<Text>().text = room.Name.Split('_')[0];

                Rooms[room.Name.Split('_')[0]] = tempRoom;
            }
        }
    }

    public void CreateRoom() {
        string roomName = RoomNameCreate.text + "_" + RoomPasswdCreate.text;

        if(roomName[0] == '_') { // empty roomname
            mainScript.GetComponent<MoveCanvas>().OpenError("Input Error", "Enter room name");
            return;
        }
        else if(Rooms.ContainsKey(RoomNameCreate.text)) { // same roomname
            mainScript.GetComponent<MoveCanvas>().OpenError("Room Create Error", "Room already exists");
            return;
        }

        publicData.GetComponent<PublicData>().roomName = roomName;

        SceneManager.LoadScene("Auditorium");
    }

    public void EnterRoom() {
        string roomName = RoomNameEnter.text + "_" + RoomPasswdEnter.text;

        if(roomName[0] == '_') { // empty roomname
            mainScript.GetComponent<MoveCanvas>().OpenError("Input Error", "Enter room name");
            return;
        }
        else if(Rooms.ContainsKey(RoomNameEnter.text) == false) { // no matching roomname
            mainScript.GetComponent<MoveCanvas>().OpenError("Room Enter Error", "No room with name and password");
            return;
        }
        else if(false) { // wrong password
            //
            //return;
        }

        publicData.GetComponent<PublicData>().roomName = roomName;

        SceneManager.LoadScene("Auditorium");
    }
}
