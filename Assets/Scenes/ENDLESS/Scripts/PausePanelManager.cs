using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanelManager : MonoBehaviour
{
    SoundsManagerScript soundsManagerScript;

    EndlessGameManager endlessGameManager;

    Button pauseButton;

    GameObject pausePanel;
    Button resumeButton;
    Button homeButton;
    Button mapButton;
    Button retryButton;

    bool hideFlag = false;

    void Start()
    {
        soundsManagerScript = GameObject.Find("SoundsManager").GetComponent<SoundsManagerScript>();

        endlessGameManager = GameObject.Find("EndlessGameManager").GetComponent<EndlessGameManager>();

        pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();

        pausePanel = GameObject.Find("PausePanel");
        resumeButton = GameObject.Find("PausePanelResumeButton").GetComponent<Button>();
        homeButton = GameObject.Find("PausePanelHomeButton").GetComponent<Button>();
        mapButton = GameObject.Find("PausePanelMapButton").GetComponent<Button>();
        retryButton = GameObject.Find("PausePanelRetryButton").GetComponent<Button>();

        pauseButton.onClick.AddListener(PauseButton);
        resumeButton.onClick.AddListener(ResumeButton);
        homeButton.onClick.AddListener(HomeButton);
        mapButton.onClick.AddListener(MapButton);
        retryButton.onClick.AddListener(RetryButton);
    }

    void Update()
    {
        VisibilityHandler();
    }

    void VisibilityHandler()
    {
        if (hideFlag == false)
        {
            pausePanel.SetActive(false);
            hideFlag = true;
        }
    }

    public void PauseButton()
    {
        soundsManagerScript.SoundButonClick();
        if (endlessGameManager.isGameActive == true)
        {
            endlessGameManager.PauseHandler();
            pausePanel.SetActive(true);
        }
    }

    public void ResumeButton()
    {
        soundsManagerScript.SoundButonClick();
        if (endlessGameManager.isGameActive == false)
        {
            endlessGameManager.PauseHandler();
            pausePanel.SetActive(false);
        }
    }

    public void HomeButton()
    {
        soundsManagerScript.SoundButonClick();
        SceneManager.LoadScene("MainMenu");
    }

    public void MapButton()
    {
        soundsManagerScript.SoundButonClick();
        SceneDataHandler.showMapFlag = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryButton()
    {
        soundsManagerScript.SoundButonClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        endlessGameManager.isGameActive = true;
    }
}
