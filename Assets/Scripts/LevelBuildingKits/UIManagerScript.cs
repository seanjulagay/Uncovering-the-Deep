using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;
    SoundsManagerScript soundsManagerScript;

    GameObject levelCompletePanel;
    Image levelCompleteStars;
    public Sprite levelCompleteStars0;
    public Sprite levelCompleteStars1;
    public Sprite levelCompleteStars2;
    public Sprite levelCompleteStars3;
    TMP_Text levelCompleteScoreText;

    GameObject gameOverPanel;

    public static GameObject activeTrappedAnimalTrigger = null;

    // public TMP_Text trashCountText;
    // public TMP_Text oxygenCountText;
    // public TMP_Text dialogueText;
    // public TMP_Text freeingProgressText;
    // public TMP_Text animalsFreedText;
    public TMP_Text helperText;

    TMP_Text timeSpentText;

    string currentDialogue;
    public int dialogueDecaySecs;

    public bool listenForInteraction = false;

    bool levelCompletePanelDisabled = false;
    bool gameOverPanelDisabled = false;

    int timeSpent;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        levelCompletePanel = GameObject.Find("LevelCompletePanel");
        levelCompleteStars = levelCompletePanel.transform.Find("LevelCompleteStars").gameObject.GetComponent<Image>();
        levelCompleteScoreText = levelCompletePanel.transform.Find("LevelCompleteHeaderText").gameObject.GetComponent<TMP_Text>();
        helperText = GameObject.Find("HelperText").GetComponent<TMP_Text>();

        gameOverPanel = GameObject.Find("GameOverPanel");

        soundsManagerScript = GameObject.Find("SoundsManager").GetComponent<SoundsManagerScript>();

        timeSpentText = GameObject.Find("TimeSpentText").GetComponent<TMP_Text>();
    }

    void Update()
    {
        TimeSpentTextHandler();
        PanelFlags();
    }

    void PanelFlags()
    {
        if (levelCompletePanelDisabled == false)
        {
            levelCompletePanel.SetActive(false);
            levelCompletePanelDisabled = true;
        }

        if (gameOverPanelDisabled == false)
        {
            gameOverPanel.SetActive(false);
            gameOverPanelDisabled = true;
        }
    }

    public void UpdateHelperText(string text = "")
    {
        helperText.text = text;
    }

    // public void OliveDialogue(string dialogue)
    // {
    //     // dialogueText.fontStyle = FontStyles.Italic;
    //     UpdateDialogueUI("<i>" + dialogue + "</i>");
    //     // dialogueText.fontStyle ^= FontStyles.Italic;
    // }

    // public void UpdateDialogueUI(string dialogue)
    // {
    //     dialogueText.enabled = true;
    //     dialogueText.text = dialogue;
    //     StopCoroutine("DialogueTextDecay");
    //     StartCoroutine("DialogueTextDecay");
    // }

    // IEnumerator DialogueTextDecay()
    // {
    //     yield return new WaitForSeconds(dialogueDecaySecs);
    //     dialogueText.enabled = false;
    // }

    public void TimeSpentTextHandler()
    {
        // Debug.Log(TimeSpan.FromSeconds(GameManagerScript.timeSpentSecs).Minutes + ":" + TimeSpan.FromSeconds(GameManagerScript.timeSpentSecs).Seconds);

        if (timeSpentText != null)
        {
            timeSpentText.text = "Time Spent: " + TimeSpan.FromSeconds(gameManagerScript.timeSpentSecs).Minutes.ToString("00") + ":" + TimeSpan.FromSeconds(gameManagerScript.timeSpentSecs).Seconds.ToString("00");
        }
    }

    public void DisplayLevelCompletePanel(int userScore)
    {
        Time.timeScale = 0;
        levelCompletePanel.SetActive(true);
        levelCompleteScoreText.text = "Score: " + userScore.ToString() + "/3";

        // Quiz system scoring
        if (userScore == 0)
        {
            levelCompleteStars.sprite = levelCompleteStars0;
        }
        else if (userScore == 1)
        {
            levelCompleteStars.sprite = levelCompleteStars1;
        }
        else if (userScore == 2)
        {
            levelCompleteStars.sprite = levelCompleteStars2;
        }
        else if (userScore == 3)
        {
            levelCompleteStars.sprite = levelCompleteStars3;
        }
    }

    public void DisplayGameOverPanel()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        // soundsManagerScript.PlaySound("victory");
    }


}
