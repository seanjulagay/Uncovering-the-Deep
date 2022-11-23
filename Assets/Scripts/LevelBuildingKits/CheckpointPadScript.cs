using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointPadScript : MonoBehaviour
{
    CheckpointManagerScript checkpointManagerScript;
    GameObject checkpointParentObj;

    void Start()
    {
        checkpointManagerScript = GameObject.Find("CheckpointManager").GetComponent<CheckpointManagerScript>();
        checkpointParentObj = gameObject.transform.parent.gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Checkpoint passed");
        checkpointManagerScript.CheckpointPassed();
        checkpointManagerScript.SpawnTrashbag(gameObject.transform.position);
        checkpointParentObj.SetActive(false);
    }
}
