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
      Cursor.lockState = CursorLockMode.Confined;
      UploadButton.gameObject.SetActive(true);
    }
  }
  void OnTriggerExit(Collider other) {
    Cursor.lockState = CursorLockMode.Locked;
    UploadButton.gameObject.SetActive(false);
  }
}
