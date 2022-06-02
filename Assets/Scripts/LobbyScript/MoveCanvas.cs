using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveCanvas : MonoBehaviour
{
    public GameObject LoginCanvas, LobbyCanvas, CreateRoomPopUp, ErrorPopUp;
    
    void Start() {
        LoginCanvas.SetActive(false);
        LobbyCanvas.SetActive(true);
        CreateRoomPopUp.SetActive(false);
        ErrorPopUp.SetActive(false);
    }

    public void OpenCreateRoom() {
        CreateRoomPopUp.SetActive(true);
    }

    public void CloseCreateRoom() {
        CreateRoomPopUp.SetActive(false);
    }

    public void OpenError(string name, string message) {
        // set error
        ErrorPopUp.transform.GetChild(2).gameObject.GetComponent<Text>().text = name;
        ErrorPopUp.transform.GetChild(3).gameObject.GetComponent<Text>().text = message;
        ErrorPopUp.SetActive(true);
    }

    public void CloseError() {
        ErrorPopUp.SetActive(false);
    }
}
