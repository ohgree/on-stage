using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainMenuTrigger : MonoBehaviour {
  // Start is called before the first frame update
  public GameObject mainMenu;
  public CinemachineVirtualCameraBase cam; // workaround
  public bool visible = false;

  void Start() {
    mainMenu.SetActive(visible);
    Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetButtonDown("Cancel")) {
      visible = !visible;
      mainMenu.SetActive(visible);
      cam.enabled = !visible;
      Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
    }
  }
}
