using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    UIManagerScript uiManagerScript;
    CheckpointManagerScript checkpointManagerScript;
    SoundsManagerScript soundsManagerScript;
    GameObject playerObj;

    [Tooltip("Gamemode 0 - exploration mode; Gamemode 1 - restoration mode")]
    public int gameMode = 0;
    [Tooltip("0 = animals saved type, 1 = timer type, 2 = quiz type")]
    public int endGameType = 1;
    public bool inTestingMode = true;

    public int starsThisLevel = 0;

    public int trashCount = 0;
    public int animalsSaved = 0;
    public int animalsMet = 0;
    public int currentCheckpoint = 0;
    public int trashbagStackCount = 0;

    public int timeSpentSecs = 0;

    public bool inStackingState = false;
    public bool isGameActive = true;

    public bool activateReturnPoint = false;

    public int userScore = 0;

    float timeSpent = 0;

    GameObject startPoint, finishPoint, returnPoint;

    [Tooltip("[1] = one star timer goal, [2] = two star timer goal, [3] = three star timer goal // CONVERT TO SECONDS")]
    public int[] timeGoals = new int[4] { 0, 0, 0, 0 };

    void Start()
    {
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        checkpointManagerScript = GameObject.Find("CheckpointManager").GetComponent<CheckpointManagerScript>();
       // soundsManagerScript = GameObject.Find("SoundsManager").
        // GetComponent<SoundsManagerScript>();

        playerObj = GameObject.Find("Player");

        startPoint = GameObject.Find("StartPoint");
        finishPoint = GameObject.Find("FinishPoint");
        returnPoint = GameObject.Find("ReturnPoint");

        StartGame();
        Time.timeScale = 1;

        
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
        // if (inTestingMode == false)
        // {
        //     playerObj.transform.position = checkpointManagerScript.startPoint.transform.position;
        // }
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

    public void LevelCompletedQuiz(int quizScore = 0)
    {
        Time.timeScale = 0;
        userScore = quizScore;
        uiManagerScript.DisplayLevelCompletePanel(userScore);
    }

    // //SOUNDS
    // public void playGameOverSound()
    // {
    //     soundsManagerScript.PlaySound("GameoverSound");
    // }

    // public void playVictorySound()
    // {
    //     soundsManagerScript.PlaySound("Sound");
    // }


}
