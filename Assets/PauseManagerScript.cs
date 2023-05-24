using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManagerScript : MonoBehaviour
{
    public Button pauseLevelButton;
    public Button resumeLevelButton;
    public Button backToMainMenuButton;
    public Button retryLevelButton;
    public Button mapSelectButton;

    //back to level select button here

    public GameObject pausePanel;
    public GameObject gameManagerScript;
    
    bool hideflag = false;
    void Start()
    {
        pausePanel = GameObject.Find("PausePanel");

        pauseLevelButton = GameObject.Find("PauseButton").GetComponent<Button>();
        pauseLevelButton.onClick.AddListener(pauseGame);

        resumeLevelButton = GameObject.Find("PausePanelResumeButton").GetComponent<Button>();
        resumeLevelButton.onClick.AddListener(resumeGame);

        backToMainMenuButton = GameObject.Find("PausePanelHomeButton").GetComponent<Button>();
        backToMainMenuButton.onClick.AddListener(backToMainMenu);

        retryLevelButton = GameObject.Find("PausePanelRetryButton").GetComponent<Button>();
        retryLevelButton.onClick.AddListener(retryLevel);
        
        mapSelectButton = GameObject.Find("LevelCompleteMapButton").GetComponent<Button>();
        mapSelectButton.onClick.AddListener(levelSelect);

    }

    public void pauseGame()
    {
        //achievementsPanel.SetActive(false);
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void resumeGame()
    {
        //achievementsPanel.SetActive(false);
        Time.timeScale = 1;
        // GameObject pausePanel = GameObject.Find("PausePanel");
        pausePanel.SetActive(false);
        // hideflag = true;
        Debug.Log("hgfhdfghdfgh");
    }

    public void backToMainMenu(){
        SceneManager.LoadScene("MainMenu");
        //SceneDataHandler.transferTempDataFlag = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("hgfhdfghdfgh");
    }
    
    public void retryLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void levelSelect(){
        SceneManager.LoadScene("MainMenu");
        MenuManagerScript.OpenZone();
    }

    void Update()
    {
         if (hideflag == false)
        {
            pausePanel.SetActive(false);
           // descAreaRealLifeImage.SetActive(false);
            hideflag = true;
        }
    }
}
