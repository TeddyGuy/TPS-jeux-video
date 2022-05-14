using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{

    float timer;
    public bool running;
    public GameObject timerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        
    }

    public void StartTimer() {
        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }
        float seconds = Mathf.FloorToInt(timer % 60);
        float minutes = Mathf.FloorToInt(timer / 60);
        string time = minutes + ":" + seconds;

        timerDisplay.GetComponent<UnityEngine.UI.Text>().text = time;
    }

    public void ResetTimer()
    {
        timer = 0;
    }
}
