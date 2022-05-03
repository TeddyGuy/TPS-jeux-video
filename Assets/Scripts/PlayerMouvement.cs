using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float speed = 30f;
    Vector3 mouvementDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        rb.MovePosition(transform.position + (mouvementDirection * speed * Time.deltaTime) );
    }

    private void GetMouvementInput() {
        mouvementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
