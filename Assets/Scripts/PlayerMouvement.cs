using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    CharacterController controller;
    public float speed = 30f;
    Vector3 mouvementDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMouvementInput();
    }

    private void FixedUpdate()
    {
        Move(mouvementDirection);
    }

    private void Move(Vector3 mouvementDirection)
    {
        controller.Move(mouvementDirection * speed * Time.deltaTime);
    }

    private void GetMouvementInput() {
        mouvementDirection = (transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"));
    }
}
