using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class EndlessUIManager : MonoBehaviour
{
    TMP_Text levelText;
    TMP_Text timerText;
    TMP_Text scoreText;
    EndlessGameManager endlessGameManager;
    EndlessPlayerPropertiesScript endlessPlayerPropertiesScript;

    void Start()
    {
        levelText = GameObject.Find("LevelText").GetComponent<TMP_Text>();
        timerText = GameObject.Find("TimerText").GetComponent<TMP_Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        endlessGameManager = GameObject.Find("EndlessGameManager").GetComponent<EndlessGameManager>();
        endlessPlayerPropertiesScript = GameObject.Find("Player").GetComponent<EndlessPlayerPropertiesScript>();
    }

    void Update()
    {
        ScoreTextHandler();
        TimeSpentTextHandler();
    }

    public void ScoreTextHandler()
    {
        scoreText.text = "Score: " + endlessGameManager.playerScore;
    }

    public void TimeSpentTextHandler()
    {
        // Debug.Log(TimeSpan.FromSeconds(GameManagerScript.timeSpentSecs).Minutes + ":" + TimeSpan.FromSeconds(GameManagerScript.timeSpentSecs).Seconds);

        if (timerText != null)
        {
            levelText.text = "Level " + (endlessPlayerPropertiesScript.oxygenDecreaseMultiplier + 1f);
            // timerText.text = "Time Spent: " + TimeSpan.FromSeconds(endlessGameManager.timeSpentSecs).Minutes.ToString("00") + ":" + TimeSpan.FromSeconds(endlessGameManager.timeSpentSecs).Seconds.ToString("00");
            timerText.text = "Next level in: " + TimeSpan.FromSeconds(endlessPlayerPropertiesScript.timer).Minutes.ToString("00") + ":" + TimeSpan.FromSeconds(endlessPlayerPropertiesScript.timer).Seconds.ToString("00");
        }
    }
}
