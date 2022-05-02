using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  public float speed;

  float hAxis;
  float vAxis;
  bool wDown;

  Vector3 moveVec;

  Animator anim;


  // Start is called before the first frame update
  void Start() { }

  private void Awake() {
    anim = GetComponentInChildren<Animator>();
  }

  // Update is called once per frame
  void Update() {
    GetInput();
    moveVec = new Vector3(hAxis, 0, vAxis).normalized;

    transform.position += moveVec * speed * Time.deltaTime * (wDown ? 0.3f : 1.0f);

    anim.SetBool("isRunning", moveVec != Vector3.zero);
    anim.SetBool("isWalking", wDown);

    transform.LookAt(transform.position + moveVec);
  }

  void GetInput() {
    hAxis = Input.GetAxisRaw("Horizontal");
    vAxis = Input.GetAxisRaw("Vertical");
    wDown = Input.GetButton("Walk");
  }
}
