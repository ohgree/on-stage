using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour {
  public Transform cam;

  public float speed = 6.0f;
  public float jumpHeight = 0.2f;
  public float gravityMultiplier = 0.5f;
  public float turnSmoothTime = 0.1f;
  public float dodgeSpeedMultiplier = 2.5f;

  CharacterController controller;
  Animator animator;

  float turnSmoothVelocity;
  float ySpeed = 0f;
  bool isJumping = false;
  bool isDodging = false;

  private void Start() {
    controller = GetComponent<CharacterController>();
    animator = GetComponentInChildren<Animator>();
  }

  // Update is called once per frame
  void Update() {
    float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Vertical");
    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
    Vector3 moveDir = new Vector3();

    if (direction != Vector3.zero) {
      float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
      float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
      transform.rotation = Quaternion.Euler(0f, angle, 0f);
      moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

      // Dodge
      if (Input.GetButtonDown("Dodge") && !isJumping && !isDodging) {
        speed *= dodgeSpeedMultiplier;
        animator.SetTrigger("dodge");
        isDodging = true;
        Invoke("DodgeOut", 0.6f);
      }
    }

    // Gravity
    ySpeed += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
    if (controller.isGrounded) {
      ySpeed = 0f; // Reset gravity if on ground
      isJumping = false;
      animator.SetBool("isJumping", false);
    }

    // Jump
    if (Input.GetButtonDown("Jump") && !isJumping && !isDodging) {
      ySpeed = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
      isJumping = true;
      animator.SetBool("isJumping", true);
      animator.SetTrigger("jump");
    }
    moveDir.y = ySpeed;

    controller.Move(moveDir * speed * Time.deltaTime);
    animator.SetBool("isMoving", direction != Vector3.zero);
  }

  void DodgeOut() {
    speed /= dodgeSpeedMultiplier;
    isDodging = false;
  }
}
