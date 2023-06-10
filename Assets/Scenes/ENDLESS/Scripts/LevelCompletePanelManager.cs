using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelCompletePanelManager : MonoBehaviour
{
    SoundsManagerScript soundsManagerScript;

    EndlessGameManager endlessGameManager;
    GameObject levelCompletePanel;
    TMP_Text levelScoreText;

    Button retryButton;
    Button homeButton;
    Button mapButton;

    bool hideFlag = false;

    void Start()
    {
        soundsManagerScript = GameObject.Find("SoundsManager").GetComponent<SoundsManagerScript>();

        endlessGameManager = GameObject.Find("EndlessGameManager").GetComponent<EndlessGameManager>();

        levelCompletePanel = GameObject.Find("LevelCompletePanel");
        levelScoreText = GameObject.Find("LevelCompleteScoreText").GetComponent<TMP_Text>();

        retryButton = GameObject.Find("LevelCompleteRetryButton").GetComponent<Button>();
        homeButton = GameObject.Find("LevelCompleteHomeButton").GetComponent<Button>();
        mapButton = GameObject.Find("LevelCompleteMapButton").GetComponent<Button>();

        retryButton.onClick.AddListener(RetryButton);
        homeButton.onClick.AddListener(HomeButton);
        mapButton.onClick.AddListener(MapButton);
    }

    void Update()
    {
        if (hideFlag == false)
        {
            levelCompletePanel.SetActive(false);
            hideFlag = true;
        }
    }

    void RetryButton()
    {
        soundsManagerScript.SoundButonClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        endlessGameManager.isGameActive = true;
    }

    void HomeButton()
    {
        soundsManagerScript.SoundButonClick();
        SceneManager.LoadScene("MainMenu");
    }

    void MapButton()
    {
        soundsManagerScript.SoundButonClick();
        SceneDataHandler.showMapFlag = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowLevelCompletePanel()
    {
        soundsManagerScript.SoundButonClick();
        levelCompletePanel.SetActive(true);
        levelScoreText.text = "Score: " + endlessGameManager.playerScore.ToString();
    }
}
