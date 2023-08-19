using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public Text currentTimeText;
    private bool timer;

    void Start()
    {
        currentTime = 0f;
        isTimer(true);
    }

    void Update()
    { 

        currentTimeText.text = currentTime.ToString();
        if (timer)
        {
            currentTime += Time.deltaTime;
        }
        
    }
    public void isTimer(bool timerActive)
    {
        timer = timerActive;
    }
    
}
