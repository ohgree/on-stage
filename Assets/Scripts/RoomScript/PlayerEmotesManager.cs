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
    }
    if (Input.GetKeyDown(KeyCode.Alpha2)) {
      animator.SetTrigger("attention");
    }
    if (Input.GetKeyDown(KeyCode.Alpha3)) {
      animator.SetTrigger("talk");
    }
    if (Input.GetKeyDown(KeyCode.C)) {
      animator.SetBool("isClapping", true);
    } else if (Input.GetKeyUp(KeyCode.C)) {
      animator.SetBool("isClapping", false);
    }
    if (Input.GetKeyDown(KeyCode.E)) {
      animator.SetBool("isSitting", !animator.GetBool("isSitting"));
    }
  }
}
