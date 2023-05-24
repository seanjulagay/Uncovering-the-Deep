using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionButtonsManagerScript : MonoBehaviour
{
    Button achievementsButton;
    Button interactButton;
    Button talkButton;
    Button almanacButton;

    GameObject almanacPanel;
    GameObject achievementsPanel;
    GameObject dialoguePanel;

    AquariumDialogueManagerScript aquariumDialogueManagerScript;

    public int animalInteractionMode = 0; // 0 = none, 1 = interact, 2 = talk

    void Start()
    {
        achievementsButton = GameObject.Find("AchievementsButton").GetComponent<Button>();
        interactButton = GameObject.Find("InteractButton").GetComponent<Button>();
        talkButton = GameObject.Find("TalkButton").GetComponent<Button>();
        almanacButton = GameObject.Find("AlmanacButton").GetComponent<Button>();

        almanacPanel = GameObject.Find("AlmanacPanel");
        achievementsPanel = GameObject.Find("AchievementsPanel");
        dialoguePanel = GameObject.Find("DialoguePanel");

        aquariumDialogueManagerScript = GameObject.Find("DialogueManager").GetComponent<AquariumDialogueManagerScript>();

        AddListeners();
    }

    void AddListeners()
    {
        achievementsButton.onClick.AddListener(OpenAchievementsPanel);
        interactButton.onClick.AddListener(InteractButton);
        talkButton.onClick.AddListener(TalkButton);
        almanacButton.onClick.AddListener(OpenAlmanacPanel);
    }

    public void OpenAlmanacPanel()
    {
        Debug.Log("ALMANAC");
        almanacPanel.SetActive(true);
        animalInteractionMode = 0;
        aquariumDialogueManagerScript.HideDialoguePanel();
    }

    public void InteractButton()
    {
        dialoguePanel.SetActive(false);
        animalInteractionMode = 1;
        aquariumDialogueManagerScript.dialogueIndex = 0;
    }

    public void TalkButton()
    {
        dialoguePanel.SetActive(false);
        animalInteractionMode = 2;
        aquariumDialogueManagerScript.dialogueIndex = 0;
    }

    public void OpenAchievementsPanel()
    {
        Debug.Log("ACHIEVEMENTS");
        achievementsPanel.SetActive(true);
        animalInteractionMode = 0;
        aquariumDialogueManagerScript.HideDialoguePanel();
    }
}
