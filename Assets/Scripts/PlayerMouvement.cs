using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    CharacterController controller;
    public float speed = 30f;
    public float gravity = -9.81f;

    public float jumpForceMax = 25f;
    public float jumpForceMin = 8f;
    public float jumpForceChargeSpeed = 8f;
    private float jumpForceBuiltUp;

    public float dashForce = 100f;
    public float dashTime = 0.25f;
    public float dashCoolDownMax = 10f;
    private float dashCoolDown;

    private Vector3 velocity;
    Vector3 mouvementDirection;
    void Start()
    {
        dashCoolDown = 0;
        jumpForceBuiltUp = 0f;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCoolDowns();
        HandleInputs();
        Move();
        ApplyGravity();
    }
    private void HandleInputs()
    {
        GetMouvementInput();

        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                ChargeJump();
            }
            else {
                if (jumpForceBuiltUp > 0f) {
                    Jump();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(dashCoolDown);
            if (DashIsReady()) {
                dashCoolDown = 0f;
                StartCoroutine(Dash());
            }
        }
    }

    private void GetMouvementInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        mouvementDirection = (transform.right * x) + (transform.forward * z);
    }

    private void Move()
    {
        controller.Move(mouvementDirection * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    private void ApplyGravity() {
        velocity.y = (controller.isGrounded && velocity.y < 0 ? -1f : velocity.y - gravity * -2f * Time.deltaTime);
    }

    private void ChargeJump() {
        jumpForceBuiltUp += jumpForceChargeSpeed * Time.deltaTime;
    }

    private void Jump() {
        var jumpForce = Mathf.Clamp(jumpForceBuiltUp, jumpForceMin, jumpForceMax);
        velocity.y = jumpForce;
        jumpForceBuiltUp = 0f;
    }
    private bool DashIsReady() {
        return dashCoolDown == dashCoolDownMax;
    }
    private IEnumerator Dash() {
        float start = Time.time;
        while (Time.time < start + dashTime) {
            controller.Move(transform.forward * dashForce * Time.deltaTime);
            yield return null;
        }
    }
    private void HandleCoolDowns() {
        dashCoolDown = Mathf.Clamp(dashCoolDown + Time.deltaTime, 0, dashCoolDownMax);
    }
}
