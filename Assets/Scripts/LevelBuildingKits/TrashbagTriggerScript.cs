using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashbagTriggerScript : MonoBehaviour
{
    GameObject trashbag;
    TrashbagScript trashbagScript;
    TrashbagStackManager trashbagStackManager;

    void Start()
    {
        trashbag = gameObject.transform.parent.gameObject;
        trashbagScript = trashbag.GetComponent<TrashbagScript>();
        trashbagStackManager = GameObject.Find("TrashbagStackManager").GetComponent<TrashbagStackManager>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Trashbag" || other.gameObject.tag == "Terrain") && trashbagScript.isStacked == true)
        {
            trashbag.tag = "Trashbag";
            trashbagScript.isStacked = false;
            Debug.Log("Removing trashbag from stack");
            trashbagStackManager.stackCount--;
        }
    }
}
