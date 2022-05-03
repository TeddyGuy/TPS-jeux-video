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
    public float jumpForce = 8f;

    private Vector3 velocity;

    public LayerMask groundLayer;
    Vector3 mouvementDirection;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        Move();
        ApplyGravity();
    }
    private void HandleInput()
    {
        GetMouvementInput();

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space)) { Jump(); }
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
        velocity.y = (controller.isGrounded && velocity.y < 0 ? -1f : velocity.y - gravity * -2f * Time.deltaTime ); 
    }

    private void Jump() {
        Debug.Log("Jump!");
        velocity.y = jumpForce;
    }

    

    
    
}
