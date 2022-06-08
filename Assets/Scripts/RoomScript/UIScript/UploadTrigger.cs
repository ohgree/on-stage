using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class UploadTrigger : MonoBehaviour {
  public Button UploadButton;
  public void Start() {
    UploadButton.gameObject.SetActive(false);
  }
  void OnTriggerEnter(Collider other) {
    if (PhotonNetwork.IsMasterClient) {
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
      UploadButton.gameObject.SetActive(true);
    }
  }
  void OnTriggerExit(Collider other) {
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Confined;
    UploadButton.gameObject.SetActive(false);
  }
}
