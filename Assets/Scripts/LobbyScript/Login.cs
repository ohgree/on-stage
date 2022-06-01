using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public GameObject MainScript;
    public Text PlayerIDText, PlayerPasswdText;
    public GameObject LoginCanvas, LobbyCanvas;

    string PlayerID, PlayerPasswd;
    
    void Start() {
        //
    }

    public void EnterLobby() {
        PlayerID = PlayerIDText.text;
        PlayerPasswd = PlayerPasswdText.text;
        // send to server for login
        // if correct ID/passwd, login
        MainScript.GetComponent<Lobby>().WelcomePlayer.text
            = "Welcome " + PlayerID;

        LoginCanvas.SetActive(false);
        LobbyCanvas.SetActive(true);
    }

    void Update() {
        
    }
}
