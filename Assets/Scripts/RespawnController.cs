using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public Vector3 lastCheckpoint = new Vector3(0,5,0);
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        lastCheckpoint = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag.Equals("Player"))
        {
            Debug.Log("test respawn");
            controller.enabled = false;
            other.gameObject.transform.position = new Vector3(lastCheckpoint.x, lastCheckpoint.y + 5, lastCheckpoint.z);
            controller.enabled = true;
        }
    }

    public void Reset()
    {
        lastCheckpoint = new Vector3(0, 5, 0);
    }
}
