using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialoguePanelManagerScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;

    public GameObject dialoguePanel;
    public GameObject dialoguePanelHolder;
    public TMP_Text dialogueText;
    public TMP_Text dialogueActorText;
    public Image dialogueActorImage;

    GameObject helperTextObj;

    List<string> diaText = new List<string>();
    List<int> assignedSpeaker = new List<int>();
    List<string> diaActor = new List<string>();
    List<Sprite> diaSprite = new List<Sprite>();

    public Sprite oliveSprite;

    bool inDialogueMode = false;
    int index;

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
        Debug.Log("UPDATEDIALOGUE");
        dialogueText.text = diaText[index];
        dialogueActorText.text = diaActor[assignedSpeaker[index]];
        dialogueActorImage.sprite = diaSprite[assignedSpeaker[index]];
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
                    index++;
                    UpdateDialogue();
                }
                else
                {
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
        Debug.Log("MULTIACTORDIALOGUE");
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
        diaActor.Clear();
        diaActor.Add(dialogueActor);
        diaSprite.Clear();
        diaSprite.Add(dialougeSprite);

        StartDialogueMode();
    }

    public void OliveDialogue(List<string> dialogueTextList)
    {
        diaText = dialogueTextList;
        assignedSpeaker = new List<int>();
        for (int i = 0; i < diaText.Count; i++)
        {
            assignedSpeaker.Add(0);
        }
        diaActor.Clear();
        diaActor.Add("Olive");
        diaSprite.Clear();
        diaSprite.Add(oliveSprite);

        StartDialogueMode();
    }

    void StartDialogueMode()
    {
        inDialogueMode = true;
        index = 0;
        dialoguePanel.SetActive(true);
        gameManagerScript.ToggleGamePause(true);

        UpdateDialogue();
    }
}