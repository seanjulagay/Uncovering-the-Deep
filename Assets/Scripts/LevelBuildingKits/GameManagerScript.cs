using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public UIManagerScript uiManagerScript;
    CheckpointManagerScript checkpointManagerScript;
    GameObject playerObj;

    public bool inTestingMode = true;

    public string gameMode; // values: "exploration", "restoration"
    public int trashCount = 0;
    public int animalsFreed = 0;
    public int currentCheckpoint = 0;

    public int timeSpentSecs = 0;

    public bool inStackingState = false;
    public bool isGameActive = true;

    public int userScore = 0;

    float timeSpent = 0;

    void Start()
    {
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        checkpointManagerScript = GameObject.Find("CheckpointManager").GetComponent<CheckpointManagerScript>();
        playerObj = GameObject.Find("Player");

        StartGame();
    }

    void Update()
    {
        if (isGameActive == true)
        {
            timeSpent += Time.deltaTime;
            timeSpentSecs = Convert.ToInt32(timeSpent);
        }
    }

    void StartGame()
    {
        if (inTestingMode == false)
        {
            playerObj.transform.position = checkpointManagerScript.startPoint.transform.position;
        }
    }

    public void ToggleGamePause(bool isPaused)
    {
        if (isPaused == true)
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

    public void LevelCompleted(int quizScore = 0)
    {
        Time.timeScale = 0;
        userScore = quizScore;
        uiManagerScript.displayLevelCompletePanel(userScore);
    }
}
