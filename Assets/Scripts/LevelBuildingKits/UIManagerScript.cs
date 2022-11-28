using System.Collections;
using System.Collections.Generic;
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

    public void UpdateDialogueUI(string dialogue)
    {
        dialogueText.text = dialogue;
    }
}
