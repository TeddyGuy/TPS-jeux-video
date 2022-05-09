using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject player;
    public RespawnController respawnController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.Equals(player))
        {
            Debug.Log("test");
            respawnController.lastCheckpoint = this.gameObject;
        }
    }
}
