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

    public void OpenError() {
        // set error
        ErrorPopUp.SetActive(false);
    }

    public void CloseError() {
        ErrorPopUp.SetActive(false);
    }
}
