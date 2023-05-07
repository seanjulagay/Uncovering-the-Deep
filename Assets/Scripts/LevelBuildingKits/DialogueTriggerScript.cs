using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTriggerScript : MonoBehaviour
{
    public bool isPartOfAnimalsMetCount = false;

    GameManagerScript gameManagerScript;
    UIManagerScript uiManagerScript;
    DialoguePanelManagerScript dialoguePanelManagerScript;

    GameObject helperTextObj;
    GameObject dialougePanelObj;
    TMP_Text helperText;

    public List<string> dialogueText = new List<string>();
    public List<string> dialogueActors = new List<string>();
    public List<int> assignedDialogueSpeaker = new List<int>();
    public List<Sprite> dialogueSprites = new List<Sprite>();

    public int index = 0;
    public bool firstOpen = true;
    public bool listenForRepeat = false;
    public bool listenForNext = false;

    void Awake()
    {
        dialougePanelObj = GameObject.Find("DialoguePanel");
    }

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        dialoguePanelManagerScript = GameObject.Find("DialoguePanelManager").GetComponent<DialoguePanelManagerScript>();

        helperTextObj = GameObject.Find("HelperText");
        helperText = helperTextObj.GetComponent<TMP_Text>();

        InitializeEmpty();
    }

    void InitializeEmpty()
    {
        if (dialogueText.Count == 0)
        {
            dialogueText.Add("This trigger's text list is empty. This is placeholder text 1. From " + gameObject);
            dialogueText.Add("This trigger's text list is empty. This is placeholder text 2. From " + gameObject);
        }

        if (dialogueActors.Count == 0)
        {
            dialogueActors.Add("Sample Actor 1");
            dialogueActors.Add("Sample Actor 2");
            dialogueSprites.Add(null);
            dialogueSprites.Add(null);
        }

        if (assignedDialogueSpeaker.Count == 0)
        {
            for (int i = 0; i < dialogueText.Count; i++)
            {
                if (i % 2 == 0)
                {
                    assignedDialogueSpeaker.Add(0);
                }
                else
                {
                    assignedDialogueSpeaker.Add(1);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (firstOpen == true)
            {
                if (isPartOfAnimalsMetCount)
                {
                    gameManagerScript.animalsMet++;
                }
                StartDialogue();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // if (firstOpen == true)
            // {
            //     if (isPartOfAnimalsMetCount)
            //     {
            //         gameManagerScript.animalsMet++;
            //     }
            //     StartDialogue();
            // }
            // else
            // {
            //     Debug.Log("HELLOOOOOOOO");
            //     helperText.text = "Press spacebar to interact";
            //     listenForRepeat = true;
            // }

            if (firstOpen == false)
            {
                helperText.text = "Press spacebar to interact";
                listenForRepeat = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (firstOpen == false)
            {
                helperText.text = "";
                listenForRepeat = false;
            }
        }
    }

    void StartDialogue()
    {
        helperText.text = "";
        Debug.Log("STARTING DIALOGUE");
        index = 0;
        listenForNext = true;
        listenForRepeat = false;
        dialoguePanelManagerScript.ShowDialogue();

        UpdateDialogue();
    }

    void UpdateDialogue()
    {
        Debug.Log("UPDATING DIALOGUE");
        dialoguePanelManagerScript.UpdateDialogue(dialogueText[index], dialogueActors[assignedDialogueSpeaker[index]], dialogueSprites[assignedDialogueSpeaker[index]]);
    }

    void EndDialogue()
    {
        Debug.Log("ENDING DIALOGUE");
        firstOpen = false;
        index = 0;
        listenForNext = false;
        dialoguePanelManagerScript.HideDialogue();
    }

    void InteractButtonListener()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (listenForNext == true)
            {
                Debug.Log("GOING NEXT");
                if (index < dialogueText.Count - 1)
                {
                    index++;
                    UpdateDialogue();
                }
                else
                {
                    EndDialogue();
                }
            }
            else if (listenForRepeat == true)
            {
                Debug.Log("REPEATING");
                StartDialogue();
            }
        }
    }

    void Update()
    {
        InteractButtonListener();
        Debug.Log("DIALOGUETRIGGER FIRSTOPEN: " + firstOpen);
    }
}