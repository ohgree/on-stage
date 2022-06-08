using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EmojiMenuTrigger : MonoBehaviour {
  public GameObject menu;
  public KeyCode triggerKey;
  bool visible;

  void Start() {
    visible = false;
    menu.SetActive(visible);
  }

  void Update() {
    if (Input.GetKeyDown(triggerKey)) {
      ShowMenu(true);
    }
    if (Input.GetKeyUp(triggerKey)) {
      ShowMenu(false);
    }
  }

  void ShowMenu(bool visible) {
    this.visible = visible;
    menu.SetActive(visible);

    Cursor.lockState = visible ? CursorLockMode.Confined : CursorLockMode.Locked;
  }

  public void HideMenu() {
    ShowMenu(false);
  }
}
