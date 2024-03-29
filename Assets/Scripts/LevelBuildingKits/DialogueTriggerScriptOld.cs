using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTriggerScriptOld : MonoBehaviour
{
    GameManagerScript gameManagerScript;
    UIManagerScript uiManagerScript;
    DialoguePanelManagerScript dialoguePanelManagerScript;

    public List<string> dialogueText = new List<string>();
    public List<string> dialogueActors = new List<string>();
    public List<int> assignedDialogueSpeaker = new List<int>();
    public List<Sprite> dialogueSprites = new List<Sprite>();

    public int index = 0;
    public bool firstOpen = true;
    public bool listenForRepeat = false;
    public bool listenForNext = false;
    public bool inDialogueMode = false;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        dialoguePanelManagerScript = GameObject.Find("DialoguePanelManager").GetComponent<DialoguePanelManagerScript>();

        InitializeEmpty();
    }

    void InitializeEmpty()
    {
        if (dialogueText.Count == 0)
        {
            dialogueText.Add("This trigger's text list is empty. This is placeholder text 1.");
            dialogueText.Add("This trigger's text list is empty. This is placeholder text 2.");
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

    void StartDialogue()
    {
        index = 0;
        inDialogueMode = true;
        listenForRepeat = false;
        listenForNext = true;
        dialoguePanelManagerScript.ShowDialogue();

        UpdateDialogue();
    }

    void EndDialogue()
    {
        index = 0;
        listenForNext = false;
        inDialogueMode = false;
        dialoguePanelManagerScript.HideDialogue();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTrigger")
        {
            if (firstOpen == true)
            {
                firstOpen = false;
                StartDialogue();
            }
            else if (firstOpen == false && inDialogueMode == false)
            {
                listenForRepeat = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTrigger")
        {
            if (firstOpen == false && inDialogueMode == false)
            {
                listenForRepeat = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTrigger")
        {
            uiManagerScript.UpdateHelperText();
            listenForRepeat = false;
        }
    }

    void ListenForNext()
    {
        if (inDialogueMode == true && listenForNext == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("GOING NEXT!!!!!");
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
        }
    }

    void ListenForRepeat()
    {
        if (listenForRepeat == true)
        {
            Debug.Log("Press spacebar to interact");
            uiManagerScript.UpdateHelperText("Press spacebar to interact");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("REPEATING!!!!!");
                listenForRepeat = false;
                uiManagerScript.UpdateHelperText();
                StartDialogue();
            }
        }
    }

    void UpdateDialogue()
    {
        dialoguePanelManagerScript.UpdateDialogue(dialogueText[index], dialogueActors[assignedDialogueSpeaker[index]], dialogueSprites[assignedDialogueSpeaker[index]]);
    }

    void Update()
    {
        // Debug.Log("firstOpen: " + firstOpen);
        Debug.Log("index: " + index);
        // Debug.Log("inDialogueMode: " + inDialogueMode);
        // Debug.Log("listenForRepeat: " + listenForRepeat);
        ListenForRepeat();
        ListenForNext();
    }
}


// ================================ VERSION 1 ====================================

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class DialogueTriggerScriptOld : MonoBehaviour
// {
//     UIManagerScript uiManagerScript;
//     public bool onlyShowOneTime = true;
//     public List<string> dialogueText = new List<string>();
//     public List<int> assignedDialogueSpeaker = new List<int>();
//     public List<string> dialogueActors = new List<string>();
//     public List<Sprite> dialogueSprites = new List<Sprite>();

//     int index = 0;
//     bool firstOpen = true;
//     bool inDialogueMode = false;
//     bool listenForInteraction = false;

//     DialoguePanelManagerScript dialoguePanelManagerScript;
//     public GameObject dialoguePanel;
//     public TMP_Text dialogueTextObj;
//     public TMP_Text dialogueActorTextObj;
//     public Image dialougeActorImageObj;

//     GameObject helperTextObj;
//     TMP_Text helperText;

//     void Awake()
//     {
//         dialoguePanelManagerScript = GameObject.Find("DialoguePanelManager").GetComponent<DialoguePanelManagerScript>();
//     }

//     void Start()
//     {
//         uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();

//         helperTextObj = GameObject.Find("HelperText");
//         helperText = helperTextObj.GetComponent<TMP_Text>();


//         if (dialogueText.Count == 0)
//         {
//             Debug.Log("dialogueText empty");
//             dialogueText.Add("Sample text 1");
//             dialogueText.Add("Sample text 2");
//         }

//         if (dialogueActors.Count == 0)
//         {
//             Debug.Log("dialogueActors empty");
//             dialogueActors.Add("Sample Actor 1");
//             dialogueActors.Add("Sample Actor 2");
//             dialogueSprites.Add(null);
//             dialogueSprites.Add(null);
//         }

//         if (assignedDialogueSpeaker.Count == 0)
//         {
//             Debug.Log("assignedDialogueSpeaker empty");
//             for (int i = 0; i < dialogueText.Count; i++)
//             {
//                 if (i % 2 == 0)
//                 {
//                     assignedDialogueSpeaker.Add(0);
//                 }
//                 else
//                 {
//                     assignedDialogueSpeaker.Add(1);
//                 }
//             }
//         }
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.gameObject.name == "PlayerTrigger")
//         {
//             if (firstOpen == true)
//             {
//                 firstOpen = false;
//                 dialoguePanelManagerScript.firstOpen = false;
//                 StartDialogue();
//             }
//             else
//             {
//                 listenForInteraction = true;
//             }
//         }
//     }

//     void OnTriggerExit2D(Collider2D other)
//     {
//         if (other.gameObject.name == "PlayerTrigger")
//         {
//             uiManagerScript.UpdateHelperText();
//             listenForInteraction = false;
//         }
//     }

//     void InteractionListener()
//     {
//         if (listenForInteraction == true)
//         {
//             uiManagerScript.UpdateHelperText("Press spacebar to interact");
//             if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 listenForInteraction = false;
//                 StartDialogue();
//             }
//         }
//     }

//     void Update()
//     {
//         // NextDialogueListener();
//         InteractionListener();
//     }

//     void StartDialogue()
//     {
//         dialoguePanelManagerScript.MultiActorDialogue(dialogueText, assignedDialogueSpeaker, dialogueActors, dialogueSprites);
//     }

//     // void OnTriggerStay2D(Collider2D other)
//     // {
//     //     if (other.gameObject.name == "PlayerTrigger")
//     //     {
//     //         if (firstOpen == false)
//     //         {
//     //             listenForInteraction = true;
//     //         }
//     //     }
//     // }



//     // void StartDialogue()
//     // {
//     //     helperTextObj.SetActive(false);
//     //     index = 0;
//     //     inDialogueMode = true;
//     //     dialoguePanel.SetActive(true);
//     //     Time.timeScale = 0;
//     //     UpdateDialogue();
//     // }

//     // void UpdateDialogue()
//     // {
//     //     dialogueTextObj = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
//     //     dialogueActorTextObj = GameObject.Find("DialogueActorText").GetComponent<TMP_Text>();
//     //     dialougeActorImageObj = GameObject.Find("DialogueActorImage").GetComponent<Image>();

//     //     dialogueTextObj.text = dialogueText[index];
//     //     dialogueActorTextObj.text = dialogueActors[assignedDialogueSpeaker[index]];
//     //     dialougeActorImageObj.sprite = dialogueSprites[assignedDialogueSpeaker[index]];
//     // }

//     // void NextDialogue()
//     // {
//     //     index++;
//     //     UpdateDialogue();
//     // }

//     // void NextDialogueListener()
//     // {
//     //     if (inDialogueMode == true)
//     //     {
//     //         if (Input.GetKeyDown(KeyCode.Space))
//     //         {
//     //             Debug.Log("index: " + index + " dialogueText.count: " + dialogueText.Count);
//     //             if (index < dialogueText.Count - 1)
//     //             {
//     //                 Debug.Log("Moving to next dialogue");
//     //                 NextDialogue();
//     //             }
//     //             else
//     //             {
//     //                 helperTextObj.SetActive(true);
//     //                 inDialogueMode = false;
//     //                 Debug.Log("Dialogue terminated");
//     //                 Time.timeScale = 1;
//     //                 dialoguePanel.SetActive(false);
//     //             }
//     //         }
//     //     }
//     // }

//     // void Update()
//     // {
//     //     if(Input.GetKeyDown(KeyCode.Space)) {
//     //         DialogueToggle();
//     //     }
//     // }

//     // void OnTriggerEnter2D(Collider2D other)
//     // {
//     //     dialoguePanel.SetActive(true);
//     //     Time.timeScale = 0;
//     //     DialogueToggle();
//     // }

//     // void DialogueToggle()
//     // {
//     //     for (int i = 0; i < dialogueText.Count; i++)
//     //     {
//     //         dialogueTextObj.text = dialogueText[i];
//     //         dialogueActorTextObj.text = dialogueActors[assignedDialogueSpeaker[i]];
//     //         Debug.Log("Current dialogue actor: " + dialogueActors[assignedDialogueSpeaker[i]]);
//     //         if (dialogueActors.Count > 0)
//     //         {
//     //             dialougeActorImageObj.sprite = dialogueSprites[assignedDialogueSpeaker[i]];
//     //         }
//     //     }

//     //     Time.timeScale = 1;
//     // }
// }





// // =========================================================================================================================

// // using System.Collections;
// // using System.Collections.Generic;
// // using System.IO;
// // using UnityEngine;

// // public class DialogueTriggerScript : MonoBehaviour
// // {
// //     DialogueTriggerManagerScript dialogueTriggerManagerScript;
// //     public int dialogueIndex = 0;
// //     public string dialogueText;

// //     void Start()
// //     {
// //         dialogueTriggerManagerScript = GameObject.Find("DialogueTriggerManager").GetComponent<DialogueTriggerManagerScript>();
// //     }

// //     void OnTriggerEnter2D(Collider2D other)
// //     {


// //         // dialogueTriggerManagerScript.ChangeDialogue(dialogueIndex);
// //     }

// //     // void OnValidate() // FOR EDITOR PURPOSES ONLY !!!!!!
// //     // {
// //     //     string dialogueJsonPath = "/Data/LevelDialogueData/" + "DemoLevel" + "/LevelDialogueData.json";
// //     //     string jsonString = File.ReadAllText(Application.streamingAssetsPath + dialogueJsonPath);

// //     //     LevelDialogueClass levelDialogueClass = JsonUtility.FromJson<LevelDialogueClass>(jsonString);

// //     //     dialogueText = levelDialogueClass.dialogue[dialogueIndex];
// //     // }
// // }
