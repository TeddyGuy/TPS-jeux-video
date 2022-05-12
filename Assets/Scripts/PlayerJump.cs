using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{
    Player player;
    public Slider powerSlider;

    public float jumpForceMax = 60f;
    public float jumpForceMin = 8f;
    public float jumpForceChargeSpeed = 40f;
    private float jumpForceBuiltUp;
    public bool AutoJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        jumpForceBuiltUp = 0f;
        powerSlider.minValue = jumpForceMin;
        powerSlider.maxValue = jumpForceMax;

    }

    // Update is called once per frame
    void Update()
    {
        powerSlider.value = jumpForceBuiltUp + jumpForceMin;
        if (player.controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                ChargeJump();
            }
            else
            {
                if (AutoJump) {
                    Jump();
                } 
                else if (jumpForceBuiltUp > 0f) {
                    Jump();
                }
            }
        }
    }

    private void ChargeJump()
    {
        jumpForceBuiltUp += jumpForceChargeSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        var jumpForce = jumpForceBuiltUp + jumpForceMin;  
        jumpForce = Mathf.Clamp(jumpForce, jumpForceMin, jumpForceMax);
        player.velocity.y = jumpForce;
        jumpForceBuiltUp = 0f;
    }
}
