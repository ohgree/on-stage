using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraInputManager : MonoBehaviour {
  public KeyCode hotkey;
  public List<CinemachineVirtualCameraBase> cams;

  int activeIndex = -1;

  // Start is called before the first frame update
  void Start() {
    cams.ForEach(cam => cam.enabled = false);
    activeIndex = (++activeIndex) % cams.Count;
    cams[activeIndex].enabled = true;
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(hotkey)) {
      ShowNextCam();
    }
  }

  void ShowNextCam() {
    cams[activeIndex].enabled = false;
    activeIndex = (++activeIndex) % cams.Count;
    cams[activeIndex].enabled = true;
  }
}
