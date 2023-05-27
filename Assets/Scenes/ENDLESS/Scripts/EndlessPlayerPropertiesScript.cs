using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndlessPlayerPropertiesScript : MonoBehaviour
{
    EndlessGameManager endlessGameManager;
    public float oxygenCount = 99f;
    public float oxygenDecreaseMultiplier = 0f;
    float timerVal = 30f;
    public float timer;
    public float oxygenDecreaseTime = 30f;

    GameObject uiOxygenBar;

    void Start()
    {
        endlessGameManager = GameObject.Find("EndlessGameManager").GetComponent<EndlessGameManager>();
        uiOxygenBar = GameObject.Find("OxygenBar");
        timer = timerVal;
    }

    void Update()
    {
        PlayerOxygenHandler();
        Timer();
        // Debug.Log("timer: " + timer + " decrease: " + oxygenDecreaseMultiplier);
    }

    void Timer()
    {
        timer -= Time.deltaTime;
    }

    void PlayerOxygenHandler()
    {
        if (timer < 0)
        {
            Debug.Log("resetting");
            timer = timerVal;
            oxygenDecreaseMultiplier++;
        }
        if (oxygenCount > 0f)
        {
            oxygenCount -= Time.deltaTime + (oxygenDecreaseMultiplier * .001f);
        }
        else if (oxygenCount <= 0f)
        {
            endlessGameManager.GameOver();
        }

        uiOxygenBar.GetComponent<UIProgressBarScript>().current = (int)oxygenCount;

    }
}
