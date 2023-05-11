using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour
{
    Button levelCompeleteRetryButton;
    Button levelCompleteNextButton;
    Button levelCompleteHomeButton;
    Button levelCompleteMapButton;

    Button gameOverRetryButton;
    Button gameOverHomeButton;
    Button gameOverMapButton;

    void Start()
    {
        levelCompeleteRetryButton = GameObject.Find("LevelCompleteRetryButton").GetComponent<Button>();
        levelCompleteNextButton = GameObject.Find("LevelCompleteNextButton").GetComponent<Button>();
        levelCompleteHomeButton = GameObject.Find("LevelCompleteHomeButton").GetComponent<Button>();
        levelCompleteMapButton = GameObject.Find("LevelCompleteMapButton").GetComponent<Button>();

        gameOverRetryButton = GameObject.Find("GameOverRetryButton").GetComponent<Button>();
        gameOverHomeButton = GameObject.Find("GameOverHomeButton").GetComponent<Button>();
        gameOverMapButton = GameObject.Find("GameOverMapButton").GetComponent<Button>();

        levelCompeleteRetryButton.onClick.AddListener(ButtonRetryLevel);
        levelCompleteNextButton.onClick.AddListener(ButtonNextLevel);
        levelCompleteHomeButton.onClick.AddListener(ButtonMainMenu);
        levelCompleteMapButton.onClick.AddListener(ButtonMap);

        gameOverRetryButton.onClick.AddListener(ButtonRetryLevel);
        gameOverHomeButton.onClick.AddListener(ButtonMainMenu);
        gameOverMapButton.onClick.AddListener(ButtonMap);
    }

    public void ButtonRetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonMap()
    {
        // Load Map Scene Here
    }

    public void ButtonNextLevel()
    {
        // Load Next Level Here
    }
}
