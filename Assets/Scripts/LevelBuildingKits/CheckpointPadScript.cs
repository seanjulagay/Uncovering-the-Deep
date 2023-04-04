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
    GameObject[] trashObjs;
    public List<string> incompleteTrashDialogue = new List<string>();

    void Start()
    {
        dialoguePanelManagerScript = GameObject.Find("DialoguePanelManager").GetComponent<DialoguePanelManagerScript>();
        nextCheckpointBarrier = gameObject.transform.parent.Find("CheckpointBarrier").gameObject;
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        checkpointManagerScript = GameObject.Find("CheckpointManager").GetComponent<CheckpointManagerScript>();
        checkpointParentObj = gameObject.transform.parent.gameObject;
        incompleteTrashDialogue.Add("I should collect all the trash in this area first!");

        trashObjs = GameObject.FindGameObjectsWithTag("TrashObj");
    }

    bool AllTrashObjsCleared()
    {
        foreach (GameObject trashObj in trashObjs)
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
            if (AllTrashObjsCleared() == true)
            {
                checkpointManagerScript.CheckpointPassed();
                checkpointManagerScript.SpawnTrashbag(gameObject.transform.position);
                checkpointParentObj.SetActive(false);
                nextCheckpointBarrier.SetActive(false);
            }
            else
            {
                dialoguePanelManagerScript.OliveDialogue(incompleteTrashDialogue);
            }
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
