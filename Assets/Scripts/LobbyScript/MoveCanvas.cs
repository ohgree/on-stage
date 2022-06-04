using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveCanvas : MonoBehaviour
{
    public GameObject LoginCanvas, LobbyCanvas;
    public GameObject CreateRoomPopUp, EnterRoomPopUp, ErrorPopUp;
    
    void Start() {
        LoginCanvas.SetActive(false);
        LobbyCanvas.SetActive(true);
        CreateRoomPopUp.SetActive(false);
        EnterRoomPopUp.SetActive(false);
        ErrorPopUp.SetActive(false);
    }

    public void OpenCreateRoom() {
        if(CreateRoomPopUp.activeSelf || EnterRoomPopUp.activeSelf)
            return;

        CreateRoomPopUp.SetActive(true);
    }

    public void CloseCreateRoom() {
        CreateRoomPopUp.SetActive(false);
    }

    public void OpenEnterRoom() {
        if(CreateRoomPopUp.activeSelf || EnterRoomPopUp.activeSelf)
            return;

        EnterRoomPopUp.SetActive(true);
    }

    public void CloseEnterRoom() {
        EnterRoomPopUp.SetActive(false);
    }

    public void OpenError(string name, string message) {
        ErrorPopUp.transform.GetChild(2).gameObject.GetComponent<Text>().text = name;
        ErrorPopUp.transform.GetChild(3).gameObject.GetComponent<Text>().text = message;
        ErrorPopUp.SetActive(true);
    }

    public void CloseError() {
        ErrorPopUp.SetActive(false);
    }
}
