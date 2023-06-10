using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ButtonManagerScript : MonoBehaviour
{
    SoundsManagerScript soundsManagerScript;

    GameManagerScript gameManagerScript;

    Button levelCompeleteRetryButton;
    Button levelCompleteNextButton;
    Button levelCompleteHomeButton;
    Button levelCompleteMapButton;

    Button gameOverRetryButton;
    Button gameOverHomeButton;
    Button gameOverMapButton;

    void Start()
    {
        soundsManagerScript = GameObject.Find("SoundsManager").GetComponent<SoundsManagerScript>();

        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        levelCompeleteRetryButton = GameObject.Find("LevelCompleteRetryButton").GetComponent<Button>();
        try
        {
            levelCompleteNextButton = GameObject.Find("LevelCompleteNextButton").GetComponent<Button>();
        }
        catch (Exception e)
        {
            Debug.Log("LEVELCOMPLETENEXTBUTTON " + e);
        }
        levelCompleteHomeButton = GameObject.Find("LevelCompleteHomeButton").GetComponent<Button>();
        levelCompleteMapButton = GameObject.Find("LevelCompleteMapButton").GetComponent<Button>();

        gameOverRetryButton = GameObject.Find("GameOverRetryButton").GetComponent<Button>();
        gameOverHomeButton = GameObject.Find("GameOverHomeButton").GetComponent<Button>();
        gameOverMapButton = GameObject.Find("GameOverMapButton").GetComponent<Button>();

        levelCompeleteRetryButton.onClick.AddListener(ButtonRetryLevel);
        try
        {
            levelCompleteNextButton.onClick.AddListener(ButtonNextLevel);
        }
        catch (Exception e)
        {
            Debug.Log("LEVELCOMPLETENEXTBUTTON " + e);
        }
        levelCompleteHomeButton.onClick.AddListener(ButtonMainMenu);
        levelCompleteMapButton.onClick.AddListener(ButtonMap);

        gameOverRetryButton.onClick.AddListener(ButtonRetryLevel);
        gameOverHomeButton.onClick.AddListener(ButtonMainMenu);
        gameOverMapButton.onClick.AddListener(ButtonMap);
    }

    public void ButtonRetryLevel()
    {
        soundsManagerScript.SoundButonClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ButtonMainMenu()
    {
        soundsManagerScript.SoundButonClick();
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonMap()
    {
        soundsManagerScript.SoundButonClick();
        SceneDataHandler.showMapFlag = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonNextLevel()
    {
        soundsManagerScript.SoundButonClick();
        switch (gameManagerScript.rawLevelValue)
        {
            case 0:
                SceneManager.LoadScene("Level_1.2_Exploration");
                break;
            case 1:
                SceneManager.LoadScene("Level_2.1_Restoration");
                break;
            case 2:
                SceneManager.LoadScene("Level_2.2_Exploration");
                break;
            case 3:
                SceneManager.LoadScene("Level_3.1_Restoration");
                break;
            case 4:
                SceneManager.LoadScene("Level_3.2_Exploration");
                break;
            default:
                Debug.Log("ButtonNextLevel Error");
                break;
        }
    }
}
