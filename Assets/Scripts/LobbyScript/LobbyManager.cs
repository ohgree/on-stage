using System;
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

    // connection state
    public Text connectionInfoText;
    
    // player name
    public Text PlayerNameText;
    public GameObject PlayerRenameInput, PlayerRenameInputField;

    // room info
    public Transform RoomContent;
    public GameObject RoomEntityPrefeb;
    public Dictionary<string, Tuple<string, GameObject> > Rooms;

    // create/enter room
    public Button CreateRoomButton, EnterRoomButton;
    public Text RoomNameCreate, RoomPasswdCreate;
    public Text RoomNameEnter, RoomPasswdEnter;

    void Start() {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        CreateRoomButton.interactable = false;
        EnterRoomButton.interactable = false;
        Rooms = new Dictionary<string, Tuple<string, GameObject> >();

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

    public void PlayerRenameStart() {
        PlayerRenameInput.SetActive(true);
    }

    public void PlayerRenameComplete() {
        GameObject PlayerRenameInputText = PlayerRenameInputField.transform.GetChild(2).gameObject;
        string newName = PlayerRenameInputText.GetComponent<Text>().text;

        Debug.Log(newName);

        if(newName.Length == 0)
            return;

        PlayerNameText.GetComponent<Text>().text = newName;
        publicData.GetComponent<PublicData>().playerName = newName;
        
        PlayerRenameInput.SetActive(false);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList) {
        Tuple < string, GameObject > tempTuple = null;
        GameObject tempRoom = null;

        for(int i = 0; i < roomList.Count; i++) {
            RoomInfo room = roomList[i];
            string namePart = room.Name.Split('_')[0];
            string passPart = room.Name.Split('_')[1];

            if(room.RemovedFromList) { // deleted room
                Rooms.TryGetValue(namePart, out tempTuple);
                Destroy(tempTuple.Item2);
                Rooms.Remove(namePart);
            }
            else if(Rooms.ContainsKey(namePart) == false) { // new room
                tempRoom = Instantiate<GameObject>(RoomEntityPrefeb, Vector3.zero, Quaternion.identity, RoomContent);
                tempRoom.transform.GetChild(0).gameObject.GetComponent<Text>().text = namePart;
                tempTuple = new Tuple<string, GameObject>(passPart, tempRoom);
                Rooms[namePart] = tempTuple;
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
            mainScript.GetComponent<MoveCanvas>().OpenError("Room Enter Error", "No room with name input");
            return;
        }
        else if(!Rooms[RoomNameEnter.text].Item1.Equals(RoomPasswdEnter.text)) { // wrong password
            mainScript.GetComponent<MoveCanvas>().OpenError("Room Enter Error", "Wrong password");
            return;
        }

        publicData.GetComponent<PublicData>().roomName = roomName;

        SceneManager.LoadScene("Auditorium");
    }
}
