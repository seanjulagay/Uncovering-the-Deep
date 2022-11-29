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

    void Start()
    {
        dialogueText.text = "Placeholder dialogue text";
    }

    void Update()
    {
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

    public void UpdateDialogueUI(string dialogue, int dialogueDecaySecs = Int32.MaxValue)
    {
        if (dialogueDecaySecs != Int32.MaxValue)
        {
            dialogueText.text = dialogue;
            Debug.Log("User inputted number");
            StartCoroutine(DecayDialogue(dialogueDecaySecs));
        }
        else
        {
            dialogueText.text = dialogue;
            Debug.Log("Changed dialogue, no inputted number");
        }
    }

    IEnumerator DecayDialogue(int dialogueDecaySecs)
    {
        yield return new WaitForSeconds(dialogueDecaySecs);
        dialogueText.text = "Cleared text";
    }
}
