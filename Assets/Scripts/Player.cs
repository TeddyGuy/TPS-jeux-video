using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;

    public float gravity = -9.81f;
    public bool applyGravity = true;
    public Vector3 velocity;
    public Vector3 mouvementDirection;
    public float speed = 45f;
    public bool xAxisMouvementAllowed = true;
    public bool zAxisMouvementAllowed = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = (xAxisMouvementAllowed ? Input.GetAxis("Horizontal") : 0);
        float z = (zAxisMouvementAllowed ? Input.GetAxis("Vertical") : 0);

        mouvementDirection = (transform.right * x) + (transform.forward * z);

        controller.Move(mouvementDirection * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

        if (applyGravity) {
            Gravity();
        }
        
    }

    private void Gravity() {
        velocity.y = (controller.isGrounded ? gravity : velocity.y - gravity * -2f * Time.deltaTime);
    }

    public void SpawnAtBeginning() {
        controller.enabled = false;
        transform.position = new Vector3(0,5,0);
        controller.enabled = true;
    }
}
