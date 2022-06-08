using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;

public class EmojiManager : MonoBehaviourPunCallbacks {
  public Sprite[] emojis;

  public void OnClickEmojiButton(int index) {
    var myPlayer = GameObject.FindGameObjectsWithTag("Player").ToList().Find(player => player.GetPhotonView().IsMine);
    photonView.RPC("emoji", RpcTarget.All, myPlayer.GetComponent<PhotonView>().ViewID, index);
  }

  [PunRPC]
  void emoji(int viewID, int index) {
    var myPlayer = GameObject.FindGameObjectsWithTag("Player").ToList().Find(player => player.GetPhotonView().ViewID == viewID);
    StartCoroutine(ShowEmojiTimer(myPlayer, 3.0f, index));
  }

  IEnumerator ShowEmojiTimer(GameObject myPlayer, float seconds, int index) {
    myPlayer.GetComponentInChildren<SpriteRenderer>().sprite = emojis[index];
    yield return new WaitForSeconds(seconds);
    myPlayer.GetComponentInChildren<SpriteRenderer>().sprite = null;
  }
}
