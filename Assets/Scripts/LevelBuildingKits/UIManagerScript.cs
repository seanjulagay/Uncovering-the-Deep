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

    GameObject timeGoalsPanel;
    GameObject timeGoalsText3;
    GameObject timeGoalsText2;
    GameObject timeGoalsText1;

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
    public SlidingNotificationAnimationScript slidingNotificationAnimationScript;
    public GameObject notificationBar;

    public NotificationManager notificationManager;

    public bool timeGoalsExist = true;
    public bool timeGoalsInitialized = false;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        levelCompletePanel = GameObject.Find("LevelCompletePanel");
        levelCompleteStars = levelCompletePanel.transform.Find("LevelCompleteStars").gameObject.GetComponent<Image>();
        levelCompleteScoreText = levelCompletePanel.transform.Find("LevelCompleteHeaderText").gameObject.GetComponent<TMP_Text>();
        helperText = GameObject.Find("HelperText").GetComponent<TMP_Text>();

        gameOverPanel = GameObject.Find("GameOverPanel");

        // soundsManagerScript = GameObject.Find("SoundsManager").GetComponent<SoundsManagerScript>();

        timeSpentText = GameObject.Find("TimeSpentText").GetComponent<TMP_Text>();

        // slidingNotificationAnimationScript = GameObject.Find("AchievementUnlocked").GetComponent<SlidingNotificationAnimationScript>();

        // notificationManager = GameObject.Find("AchievementUnlocked").GetComponent<NotificationManager>();
    }

    void Update()
    {
        if (timeGoalsInitialized == false)
        {
            InitializeTimeGoalsText();
            timeGoalsInitialized = true;
        }

        TimeSpentTextHandler();
        PanelFlags();
    }

    void InitializeTimeGoalsText()
    {
        try
        {
            timeGoalsPanel = GameObject.Find("TimeGoalsPanel");

            Debug.Log("LEVEL VAL: " + gameManagerScript.levelVal);

            if (gameManagerScript.levelVal != 0)
            { // Level type is NOT restoration mode
                Debug.Log("DISABLING TIME GOALS PANEL");
                timeGoalsPanel.SetActive(false);
            }

            timeGoalsText3 = GameObject.Find("TimeGoalsText3");
            timeGoalsText2 = GameObject.Find("TimeGoalsText2");
            timeGoalsText1 = GameObject.Find("TimeGoalsText1");

            if (timeGoalsExist == true)
            {
                timeGoalsText3.GetComponent<TMP_Text>().text = gameManagerScript.timeGoals[3].ToString();
                timeGoalsText2.GetComponent<TMP_Text>().text = gameManagerScript.timeGoals[2].ToString();
                timeGoalsText1.GetComponent<TMP_Text>().text = gameManagerScript.timeGoals[1].ToString();

                timeGoalsText3.GetComponent<TMP_Text>().text = IntToMins(gameManagerScript.timeGoals[3]) + ":" + IntToSecs(gameManagerScript.timeGoals[3]);
                timeGoalsText2.GetComponent<TMP_Text>().text = IntToMins(gameManagerScript.timeGoals[2]) + ":" + IntToSecs(gameManagerScript.timeGoals[2]);
                timeGoalsText1.GetComponent<TMP_Text>().text = IntToMins(gameManagerScript.timeGoals[1]) + ":" + IntToSecs(gameManagerScript.timeGoals[1]);
            }
        }
        catch (Exception e)
        {
            timeGoalsExist = false;
            Debug.Log("Exception in initializing time goals: " + e);
        }
    }

    string IntToMins(int val)
    {
        return TimeSpan.FromSeconds(val).Minutes.ToString("00");
    }

    string IntToSecs(int val)
    {
        return TimeSpan.FromSeconds(val).Seconds.ToString("00");
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

        //slidingNotificationAnimationScript.playNotificationAnimation();
        //Debug.Log("Level completed!");
        //string message = "Level completed!";
        //notificationManager.ShowNotification();
    }

    public void DisplayGameOverPanel()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        // soundsManagerScript.PlaySound("victory");
        //slidingNotificationAnimationScript.playNotificationAnimation();
    }




}
