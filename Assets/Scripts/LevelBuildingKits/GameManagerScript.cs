using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static string gameMode; // values: "exploration", "restoration"
    public static int trashCount = 0;
    public static int animalsFreed = 0;
    public static int currentCheckpoint = 0;

    public static int timeSpentSecs = 0;

    public static bool inStackingState = false;
    public static bool isGameActive = true;

    float timeSpent = 0;

    void Start()
    {

    }

    void Update()
    {
        if (isGameActive == true)
        {
            timeSpent += Time.deltaTime;
            timeSpentSecs = Convert.ToInt32(timeSpent);
        }
    }

    public void ToggleGamePause()
    {
        if (isGameActive == true)
        {
            Time.timeScale = 0;
            isGameActive = false;
        }
        else
        {
            Time.timeScale = 1;
            isGameActive = true;
        }
    }
}
