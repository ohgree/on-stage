using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIVisibilityControl : MonoBehaviour {
  public GameObject element;
  public KeyCode key;
  public bool visible = false;
  // Start is called before the first frame update
  void Start() {
    element.SetActive(visible);
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(key)) {
      ToggleUI();
    }
  }

  void ToggleUI() {
    visible = !visible;
    element.SetActive(visible);
  }
}
