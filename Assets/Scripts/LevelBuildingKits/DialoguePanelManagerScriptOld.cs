using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialoguePanelManagerScriptOld : MonoBehaviour
{
    GameManagerScript gameManagerScript;

    GameObject dialoguePanel;
    GameObject dialoguePanelHolder;
    TMP_Text dialogueText;
    TMP_Text dialogueActorText;
    Image dialogueActorImage;

    GameObject helperTextObj;

    public List<string> diaText = new List<string>();
    public List<int> assignedSpeaker = new List<int>();
    public List<string> diaActor = new List<string>();
    public List<Sprite> diaSprite = new List<Sprite>();

    public Sprite oliveSprite;

    bool inDialogueMode = false;
    public bool firstOpen = true;
    public int index;

    void Awake()
    {
        dialoguePanel = GameObject.Find("DialoguePanel");
        dialoguePanelHolder = GameObject.Find("DialoguePanelHolder");
        dialogueText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
        dialogueActorText = GameObject.Find("DialogueActorText").GetComponent<TMP_Text>();
        dialogueActorImage = GameObject.Find("DialogueActorImage").GetComponent<Image>();

        // dialoguePanelHolder.SetActive(false);
    }

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        helperTextObj = GameObject.Find("HelperText");

        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        NextDialogueListener();
    }

    void UpdateDialogue()
    {
        dialogueText.text = diaText[index];
        dialogueActorText.text = diaActor[assignedSpeaker[index]];
        dialogueActorImage.sprite = diaSprite[assignedSpeaker[index]];
        Debug.Log("index: " + index + " diaText.count: " + diaText.Count);
    }

    void NextDialogueListener()
    {
        if (inDialogueMode == true)
        {
            if (helperTextObj.activeSelf == true)
            {
                helperTextObj.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (index < diaText.Count - 1)
                {
                    if (firstOpen == false)
                    {
                        Debug.Log("SETTING INDEX TO -1");
                        index = -1;
                    }
                    index++;
                    UpdateDialogue(); // UPDATEDIALOGUE IS CALLED TWICE, CHECK IT OUT 
                }
                else
                {
                    firstOpen = true;
                    index = 0;
                    inDialogueMode = false;
                    gameManagerScript.ToggleGamePause(false);
                    dialoguePanel.SetActive(false);
                    helperTextObj.SetActive(true);
                }
            }
        }
    }

    public void MultiActorDialogue(List<string> dialogueTextList, List<int> assignedDialogueSpeakerList, List<string> dialogueActorsList, List<Sprite> dialogueSpritesList)
    {
        diaText = dialogueTextList;
        assignedSpeaker = assignedDialogueSpeakerList;
        diaActor = dialogueActorsList;
        diaSprite = dialogueSpritesList;

        StartDialogueMode();
    }

    public void SingleActorDialogue(List<string> dialogueTextList, string dialogueActor, Sprite dialougeSprite)
    {
        diaText = dialogueTextList;
        assignedSpeaker = new List<int>();
        for (int i = 0; i < diaText.Count; i++)
        {
            assignedSpeaker.Add(0);
        }
        diaActor = new List<string> { dialogueActor };
        diaSprite = new List<Sprite> { dialougeSprite };

        StartDialogueMode();
    }

    public void OliveDialogue(List<string> dialogueTextList)
    {
        diaText = dialogueTextList;
        Debug.Log("diatext: " + diaText);
        assignedSpeaker = new List<int>();
        for (int i = 0; i < diaText.Count; i++)
        {
            assignedSpeaker.Add(0);
        }
        diaActor = new List<string> { "Olive" };
        diaSprite = new List<Sprite> { oliveSprite };

        StartDialogueMode();
    }

    void StartDialogueMode()
    {
        index = 0;
        inDialogueMode = true;
        dialoguePanel.SetActive(true);
        gameManagerScript.ToggleGamePause(true);

        UpdateDialogue();
    }
}