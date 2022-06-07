using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class EmojiManager : MonoBehaviourPunCallbacks {
    bool sendEmoji;
    bool isEmoji;
    public Sprite[] emojis;
    void Start() {
        sendEmoji = false;
        isEmoji = false;
    }

    public void OnClickEmojiButton(int index) {
        sendEmoji = true;

        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            PhotonView playerPV = player.GetComponent<PhotonView>();
            if(!playerPV.IsMine)
                continue;

            /*Debug.Log("My player");
            Debug.Log(playerPV.ViewID);
            Debug.Log(index);*/

            photonView.RPC("emoji", RpcTarget.All, playerPV.ViewID, index);
            break;
        }
    }

    [PunRPC]
    void emoji(int viewID, int index) {
         foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            PhotonView playerPV = player.GetComponent<PhotonView>();
            if(playerPV.ViewID != viewID)
                continue;
            if(isEmoji)
                return;
            StartCoroutine(ShowEmojiTimer(player, 3.0f, index));
        }
    }
    
    IEnumerator ShowEmojiTimer(GameObject myPlayer, float seconds, int index){
        //if(isEmoji)
        isEmoji = true;
        myPlayer.GetComponentInChildren<SpriteRenderer>().sprite = emojis[index];
        yield return new WaitForSeconds(seconds);
        isEmoji = false;
        myPlayer.GetComponentInChildren<SpriteRenderer>().sprite = null;
        
        /*
        myPlayer.GetComponentInChildren<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(seconds);
        myPlayer.GetComponentInChildren<SpriteRenderer>().enabled = false;
        */
    }
}
