using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  public float speed;

  float hAxis;
  float vAxis;
  bool wDown;
  bool jDown;
  bool dDown;

  bool isJumping;
  bool isDodging;
  bool isBorder;

  Vector3 moveVec;
  Vector3 dodgeVec;

  Animator anim;
  Rigidbody rigid;


  // Start is called before the first frame update
  void Start() { }

  private void Awake() {
    rigid = GetComponent<Rigidbody>();
    anim = GetComponentInChildren<Animator>();
  }

  void FreezeRotation() {
    rigid.angularVelocity = Vector3.zero;
  }

  void StopOnWall() {
    Debug.DrawRay(transform.position + Vector3.up * 0.25f, transform.forward * 0.5f, Color.green);
    isBorder = Physics.Raycast(transform.position + Vector3.up * 0.25f, transform.forward, 0.5f, LayerMask.GetMask("Wall"));
  }

  // Update is called once per frame
  void Update() {
    FreezeRotation();
    StopOnWall();
    GetInput();
    Move();
    Turn();
    Jump();
    Dodge();
  }

  void GetInput() {
    hAxis = Input.GetAxisRaw("Horizontal");
    vAxis = Input.GetAxisRaw("Vertical");
    wDown = Input.GetButton("Walk");
    jDown = Input.GetButtonDown("Jump");
    dDown = Input.GetButtonDown("Dodge");
  }

  void Move() {
    moveVec = isDodging ? dodgeVec : new Vector3(hAxis, 0, vAxis).normalized;

    if (!isBorder) {
      transform.position += moveVec * speed * Time.deltaTime * (wDown ? 0.3f : 1.0f);
    }

    anim.SetBool("isRunning", moveVec != Vector3.zero);
    anim.SetBool("isWalking", wDown);
  }

  void Turn() {
    transform.LookAt(transform.position + moveVec);
  }

  void Jump() {
    if (jDown && !isJumping && !isDodging) {
      rigid.AddForce(Vector3.up * 7, ForceMode.Impulse);
      anim.SetBool("isJumping", true);
      anim.SetTrigger("doJump");
      isJumping = true;
    }
  }

  void Dodge() {
    if (dDown && moveVec != Vector3.zero && !isJumping && !isDodging) {
      dodgeVec = moveVec;
      speed *= 2.5f;
      anim.SetTrigger("doDodge");
      isDodging = true;

      Invoke("DodgeOut", 0.6f);
    }
  }

  void DodgeOut() {
    speed *= 0.4f;
    isDodging = false;
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.tag == "Floor") {
      anim.SetBool("isJumping", false);
      isJumping = false;
    }
  }
}
