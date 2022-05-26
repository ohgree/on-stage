using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    public GameObject MainScript;

    public Text WelcomePlayer;
    public GameObject LoginCanvas, LobbyCanvas;
    
    void Start() {
        LoginCanvas.SetActive(true);
        LobbyCanvas.SetActive(false);
    }

    public void Logout() {
        LoginCanvas.SetActive(true);
        LobbyCanvas.SetActive(false);
    }

    public void EnterRoom() {
        SceneManager.LoadScene("Auditorium");
    }

    void Update() {
        //
    }
}
