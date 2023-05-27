using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndlessGameManager : MonoBehaviour
{
    EndlessPlayerPropertiesScript endlessPlayerPropertiesScript;
    LevelCompletePanelManager levelCompletePanelManager;

    GameObject player;
    GameObject entryPortal;
    public int playerScore = 0;
    float timeSpent = 0;
    public int timeSpentSecs = 0;
    public bool isGameActive = true;

    void Start()
    {
        player = GameObject.Find("Player");
        entryPortal = GameObject.Find("EntryPortal");

        player.transform.position = entryPortal.transform.position;

        endlessPlayerPropertiesScript = player.GetComponent<EndlessPlayerPropertiesScript>();
        levelCompletePanelManager = GameObject.Find("LevelCompletePanelManager").GetComponent<LevelCompletePanelManager>();
    }

    void Update()
    {
        Timer();
        Debug.Log("isGameActive: " + isGameActive);
    }

    void Timer()
    {
        if (isGameActive == true)
        {
            Time.timeScale = 1;
            timeSpent += Time.deltaTime;
            timeSpentSecs = Convert.ToInt32(timeSpent);
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void PauseHandler()
    {
        if (isGameActive == true)
        {
            isGameActive = false;
        }
        else
        {
            isGameActive = true;
        }
    }

    public void SetHighScore()
    {
        Debug.Log("playerScore: " + playerScore + " highscore: " + SceneDataHandler.activeUser.endlessHighScore);
        if (playerScore > SceneDataHandler.activeUser.endlessHighScore)
        {
            SceneDataHandler.activeUser.endlessHighScore = playerScore;
            SceneDataHandler.TransferTempData();
            Debug.Log("SET NEW ENDLESS HIGH SCORE");
        }
    }

    public void GameOver()
    {
        SetHighScore();
        Debug.Log("Game over!");
        Time.timeScale = 0f;
        levelCompletePanelManager.ShowLevelCompletePanel();
    }

}
