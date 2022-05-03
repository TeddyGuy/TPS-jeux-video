using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSensitivity = 400f;
    private Vector2 mouseDirection;
    private float xRotation;
    private float yRotation;
    private float xRotationMax = 90f;
    public Transform player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseDirection();
        MoveCamera();
    }

    private void GetMouseDirection() {
        mouseDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    private void MoveCamera() {
        xRotation -= mouseDirection.y * mouseSensitivity * Time.deltaTime;
        yRotation += mouseDirection.x * mouseSensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -xRotationMax, xRotationMax);
        
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        player.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
