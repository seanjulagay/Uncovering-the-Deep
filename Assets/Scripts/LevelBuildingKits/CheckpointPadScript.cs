using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointPadScript : MonoBehaviour
{
    public GameObject nextCheckpointBarrier;
    UIManagerScript uiManagerScript;
    CheckpointManagerScript checkpointManagerScript;
    GameObject checkpointParentObj;
    GameObject[] trashObjs;

    void Start()
    {
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        checkpointManagerScript = GameObject.Find("CheckpointManager").GetComponent<CheckpointManagerScript>();
        checkpointParentObj = gameObject.transform.parent.gameObject;

        trashObjs = GameObject.FindGameObjectsWithTag("FloatingTrash");
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
        if (AllTrashObjsCleared() == true)
        {
            checkpointManagerScript.CheckpointPassed();
            checkpointManagerScript.SpawnTrashbag(gameObject.transform.position);
            checkpointParentObj.SetActive(false);
            nextCheckpointBarrier.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (AllTrashObjsCleared() == false)
        {
            uiManagerScript.OliveDialogue("I should collect all the trash here first!");
        }
    }
}
