using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    public TMP_Text trashCountText;
    public TMP_Text oxygenCountText;
    public TMP_Text dialogueText;

    void Update()
    {
        oxygenCountText.text = "Oxygen: " + PlayerPropertiesScript.oxygenCount;
        trashCountText.text = "Trash collected: " + GameManagerScript.trashCount;
        dialogueText.text = "Dialogue goes here - link to JSON file";
    }
}
