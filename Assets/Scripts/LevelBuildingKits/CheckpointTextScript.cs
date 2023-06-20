using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointTextScript : MonoBehaviour
{
    GameObject parent;
    TMP_Text myText;
    CheckpointPadScript checkpointPadScript;

    void Start()
    {
        parent = gameObject.transform.parent.parent.gameObject;
        myText = gameObject.GetComponent<TMP_Text>();
        checkpointPadScript = gameObject.transform.parent.GetComponent<CheckpointPadScript>();
    }



    void Update()
    {
        myText.text = checkpointPadScript.collectedObjs + "/" + checkpointPadScript.totalObjs;
    }
}
