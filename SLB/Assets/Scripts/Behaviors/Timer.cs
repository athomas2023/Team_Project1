using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 200; 
    public bool timerOn = false;
    public TextMeshProUGUI timer;
    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        timer.text = timeRemaining.ToString("0");

    }

    // Update is called once per frame
    void Update()
    {
        timer.text = timeRemaining.ToString("0");
        if(timerOn)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("You failed");
                timerOn = false;
            }
        }
    }
}
