using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointPadScript : MonoBehaviour
{
    DialoguePanelManagerScript dialoguePanelManagerScript;
    GameObject nextCheckpointBarrier;
    UIManagerScript uiManagerScript;
    CheckpointManagerScript checkpointManagerScript;
    GameObject checkpointParentObj;
    List<GameObject> allTrashObjs = new List<GameObject>();
    public List<GameObject> myTrashObjs = new List<GameObject>();

    public float timer = 0;
    public bool timerRunning = false;
    public bool dialogueShown = false;
    public bool objInstantiated = false; // flag to prevent double instantiation
    float interactionCooldown = 3f;

    void Start()
    {
        dialoguePanelManagerScript = GameObject.Find("DialoguePanelManager").GetComponent<DialoguePanelManagerScript>();
        nextCheckpointBarrier = gameObject.transform.parent.Find("CheckpointBarrier").gameObject;
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        checkpointManagerScript = GameObject.Find("CheckpointManager").GetComponent<CheckpointManagerScript>();
        checkpointParentObj = gameObject.transform.parent.gameObject;
        GetTrashObjects();
    }

    void GetTrashObjects()
    {
        foreach (Transform child in transform.parent)
        {
            if (child.tag == "TrashObj")
            {
                myTrashObjs.Add(child.gameObject);
            }
        }
    }

    bool AllTrashObjsCleared()
    {
        foreach (GameObject trashObj in myTrashObjs)
        {
            if (trashObj.activeSelf == true)
            {
                return false;
            }
        }
        return true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (AllTrashObjsCleared() == true && objInstantiated == false)
            {
                objInstantiated = true;
                checkpointManagerScript.CheckpointPassed();
                checkpointManagerScript.SpawnTrashbag(gameObject.transform.position);
                checkpointParentObj.SetActive(false);
                nextCheckpointBarrier.SetActive(false);
            }
            else
            {
                if (timer == 0)
                {
                    dialogueShown = true;
                    dialoguePanelManagerScript.OliveSingleDialogue("I should collect all the trash in this area first!");
                    timerRunning = true;
                }
            }
        }
    }

    void Update()
    {
        InteractionCooldownTimer();
        InteractionButtonListener();
    }

    void InteractionCooldownTimer()
    {
        if (timerRunning == true)
        {
            timer += Time.deltaTime;
            if (timer >= interactionCooldown)
            {
                timerRunning = false;
                timer = 0;
            }
        }
    }

    void InteractionButtonListener()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueShown == true)
        {
            dialoguePanelManagerScript.HideDialogue();
            dialogueShown = false;
        }
    }

    // void OnTriggerStay2D(Collider2D other)
    // {
    //     if (AllTrashObjsCleared() == false)
    //     {
    //         // uiManagerScript.OliveDialogue("I should collect all the trash here first!");
    //     }
    // }
}
