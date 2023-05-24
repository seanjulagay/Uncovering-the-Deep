using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialoguePanelManagerScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;
    public Sprite OliveSprite;

    public GameObject dialoguePanel;
    TMP_Text dialogueText;
    TMP_Text dialogueActor;
    Image dialogueSprite;

    bool disabledDialoguePanel = false;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        dialoguePanel = GameObject.Find("DialoguePanel");
        dialogueText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
        dialogueActor = GameObject.Find("DialogueActorText").GetComponent<TMP_Text>();
        dialogueSprite = GameObject.Find("DialogueActorImage").GetComponent<Image>();
    }

    void Update()
    {
        DisableDialoguePanelOnStartup();
    }

    void DisableDialoguePanelOnStartup()
    {
        if (disabledDialoguePanel == false)
        {
            dialoguePanel.SetActive(false);
            disabledDialoguePanel = true;
        }
    }

    public void ShowDialogue()
    {
        dialoguePanel.SetActive(true);
        gameManagerScript.ToggleGamePause(true);
    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
        gameManagerScript.ToggleGamePause(false);
    }

    public void UpdateDialogue(string diaText = "NULL", string diaActor = "NULL", Sprite diaSprite = null)
    {
        dialogueText.text = diaText;
        dialogueActor.text = diaActor;
        dialogueSprite.sprite = diaSprite;
    }

    public void OliveSingleDialogue(string diaText)
    {
        ShowDialogue();
        dialogueText.text = diaText;
        dialogueActor.text = "Olive";
        dialogueSprite.sprite = OliveSprite;
    }
}
