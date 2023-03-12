using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    public GameObject levelCompletePanel;
    Image levelCompleteStars;
    public Sprite levelCompleteStars0;
    public Sprite levelCompleteStars1;
    public Sprite levelCompleteStars2;
    public Sprite levelCompleteStars3;
    TMP_Text levelCompleteScoreText;

    public static GameObject activeTrappedAnimalTrigger = null;

    public TMP_Text trashCountText;
    public TMP_Text oxygenCountText;
    public TMP_Text dialogueText;
    public TMP_Text freeingProgressText;
    public TMP_Text animalsFreedText;

    public TMP_Text timeSpentText;

    string currentDialogue;
    public int dialogueDecaySecs;

    int timeSpent;

    void Start()
    {
        levelCompleteStars = levelCompletePanel.transform.Find("LevelCompleteStars").gameObject.GetComponent<Image>();
        levelCompleteScoreText = levelCompletePanel.transform.Find("ScoreText").gameObject.GetComponent<TMP_Text>();

        dialogueText.text = "Placeholder dialogue text";
        dialogueText.enabled = false;
    }

    void Update()
    {
        TimeSpentTextHandler();

        oxygenCountText.text = "Oxygen: " + PlayerPropertiesScript.oxygenCount;
        trashCountText.text = "Trash collected: " + GameManagerScript.trashCount;
        if (activeTrappedAnimalTrigger != null)
        {
            freeingProgressText.text = "Freeing progress: " + activeTrappedAnimalTrigger.GetComponent<TrappedAnimalTriggerScript>().freeingProgress;
        }
        else
        {
            freeingProgressText.text = "No animal trapped";
        }
        animalsFreedText.text = "Animals freed: " + GameManagerScript.animalsFreed;
    }

    public void OliveDialogue(string dialogue)
    {
        // dialogueText.fontStyle = FontStyles.Italic;
        UpdateDialogueUI("<i>" + dialogue + "</i>");
        // dialogueText.fontStyle ^= FontStyles.Italic;
    }

    public void UpdateDialogueUI(string dialogue)
    {
        dialogueText.enabled = true;
        dialogueText.text = dialogue;
        StopCoroutine("DialogueTextDecay");
        StartCoroutine("DialogueTextDecay");
    }

    IEnumerator DialogueTextDecay()
    {
        yield return new WaitForSeconds(dialogueDecaySecs);
        dialogueText.enabled = false;
    }

    public void TimeSpentTextHandler()
    {
        // Debug.Log(TimeSpan.FromSeconds(GameManagerScript.timeSpentSecs).Minutes + ":" + TimeSpan.FromSeconds(GameManagerScript.timeSpentSecs).Seconds);

        if (timeSpentText != null)
        {
            timeSpentText.text = "Time Spent: " + TimeSpan.FromSeconds(GameManagerScript.timeSpentSecs).Minutes.ToString("00") + ":" + TimeSpan.FromSeconds(GameManagerScript.timeSpentSecs).Seconds.ToString("00");
        }
    }

    public void displayLevelCompletePanel(int userScore)
    {
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
}
