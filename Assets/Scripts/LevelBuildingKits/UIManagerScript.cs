using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
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
}
