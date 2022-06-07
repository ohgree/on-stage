using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class EmojiManager : MonoBehaviourPunCallbacks {
    public Sprite[] emojis;

    public void OnClickEmojiButton(int index) {
 
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            PhotonView playerPV = player.GetComponent<PhotonView>();
            if(!playerPV.IsMine)
                continue;
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

            StartCoroutine(ShowEmojiTimer(player, 3.0f, index));
        }
    }
    
    IEnumerator ShowEmojiTimer(GameObject myPlayer, float seconds, int index){
        myPlayer.GetComponentInChildren<SpriteRenderer>().sprite = emojis[index];
        yield return new WaitForSeconds(seconds);
        myPlayer.GetComponentInChildren<SpriteRenderer>().sprite = null;
    }
}
