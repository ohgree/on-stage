using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PlayerNameNetwork : MonoBehaviourPunCallbacks {
  [PunRPC]
  public void ChangePlayerName(int viewID, string playerName) {
    GameObject myPlayer = GameObject.FindGameObjectsWithTag("Player").ToList().Find(player => player.GetPhotonView().ViewID == viewID);
    myPlayer.GetComponentInChildren<TextMesh>().text = playerName;
  }
}
