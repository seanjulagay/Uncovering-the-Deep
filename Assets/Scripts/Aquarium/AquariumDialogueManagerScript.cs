using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AquariumDialogueManagerScript : MonoBehaviour
{
    GameObject dialoguePanel;
    public int dialogueIndex = 0;
    List<string> myDialogue = new List<string>();
    public List<string> interactDialogue = new List<string>();
    public List<string> interactedDialogue = new List<string>();
    bool listenForButton = false;

    TMP_Text animalName;
    Image animalSprite;
    TMP_Text animalDialogue;
    TMP_Text dialogueFooter;

    void Start()
    {
        dialoguePanel = GameObject.Find("DialoguePanel");
        animalName = GameObject.Find("DialogueHeader").GetComponent<TMP_Text>();
        animalSprite = GameObject.Find("DialogueSprite").GetComponent<Image>();
        animalDialogue = GameObject.Find("DialogueBody").GetComponent<TMP_Text>();
        dialogueFooter = GameObject.Find("DialogueFooter").GetComponent<TMP_Text>();
    }

    void InteractionButtonListener()
    {
        if (Input.GetKeyDown(KeyCode.Space) && listenForButton == true)
        {
            UpdateDialoguePanel();
            // dialogueIndex += 1;
        }
    }

    void Update()
    {
        InteractionButtonListener();
    }

    public void ImportDialogueData(string name, Sprite sprite, string importedDialogue)
    {
        dialogueFooter.text = "Press spacebar to proceed";
        animalName.text = name;
        animalSprite.sprite = sprite;
        myDialogue = new List<string>(importedDialogue.Split('/'));
        UpdateDialoguePanel();
    }

    public void InteractDialogue(GameObject obj)
    {
        dialogueFooter.text = "Press spacebar to proceed";
        animalName.text = obj.GetComponent<AnimalDialogueScript>().name;
        animalSprite.sprite = obj.GetComponent<SpriteRenderer>().sprite;
        myDialogue = interactDialogue;
        UpdateDialoguePanel();
    }

    public void AlreadyInteractedDialogue(GameObject obj)
    {
        dialogueFooter.text = "Affection level raised today!";
        animalName.text = obj.name;
        animalSprite.sprite = obj.GetComponent<SpriteRenderer>().sprite;
        myDialogue = interactedDialogue;
        UpdateDialoguePanel();
    }

    public void ShowDialoguePanel()
    {
        dialoguePanel.SetActive(true);
        listenForButton = true;
    }

    public void HideDialoguePanel()
    {
        dialoguePanel.SetActive(false);
        listenForButton = false;
        dialogueIndex = 0;
    }

    public void UpdateDialoguePanel()
    {
        if (dialogueIndex < myDialogue.Count)
        {
            animalDialogue.text = myDialogue[dialogueIndex];
            ShowDialoguePanel();
            dialogueIndex++;
        }
        else
        {
            HideDialoguePanel();
        }
    }
}
