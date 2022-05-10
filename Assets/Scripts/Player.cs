using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    
    public float gravity = -9.81f;
    public Vector3 velocity;
    Vector3 mouvementDirection;
    public float speed = 45f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        mouvementDirection = (transform.right * x) + (transform.forward * z);
        controller.Move(mouvementDirection * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
        velocity.y = (controller.isGrounded ? gravity * Time.deltaTime : velocity.y - gravity * -2f * Time.deltaTime);
    }
}
