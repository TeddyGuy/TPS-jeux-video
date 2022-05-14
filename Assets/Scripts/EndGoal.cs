using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    public TimerController timerController;
    public GameObject restartBtn;
    public MouseLook mouseLook;
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
        if (other.gameObject.CompareTag("Player"))
        {
            timerController.running = false;
            restartBtn.SetActive(true);
            mouseLook.UnLockCursor();
            mouseLook.enabled = false;
        }
    }
}
