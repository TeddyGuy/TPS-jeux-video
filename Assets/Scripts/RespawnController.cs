using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public GameObject lastCheckpoint;
    public GameObject Player;
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
        
        if (other.gameObject.Equals(Player))
        {
            Debug.Log("test respawn");
            Player.transform.position = new Vector3(0f,100f, 0f);
        }
    }
}