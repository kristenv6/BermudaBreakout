using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System;

public class KeepGameTime : MonoBehaviour
{
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GameObject.Find("GameTimer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameStats.healthTimer += Time.deltaTime;
        GameStats.gameTimer += Time.deltaTime;

        System.TimeSpan t = System.TimeSpan.FromSeconds(GameStats.gameTimer);
        string timerFormatted = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
        timerText.text = timerFormatted;
    }
}
