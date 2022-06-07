using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerEmotesManager : MonoBehaviourPunCallbacks {
  Animator animator;

  private void Start() {
    animator = GetComponentInChildren<Animator>();
  }

  // Update is called once per frame
  void Update() {
    if (!photonView.IsMine) {
      return;
    }
    if (Input.GetKeyDown(KeyCode.Alpha1)) {
      animator.SetTrigger("hello");
    } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
      animator.SetTrigger("attention");
    }
  }
}
