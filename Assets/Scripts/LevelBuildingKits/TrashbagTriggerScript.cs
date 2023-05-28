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
        if ((other.gameObject.tag == "Trashbag" || other.gameObject.tag == "Terrain" || other.gameObject.tag == "StoryAnimal" || other.gameObject.tag == "TrappedAnimal" || other.gameObject.tag == "ChasingAnimal") && trashbagScript.isStacked == true)
        {
            trashbagStackManager.stackCount--;
            trashbagScript.isStacked = false;
            trashbag.tag = "Trashbag";
        }

        // if ((other.gameObject.tag != "TrashbagStacked" || other.gameObject.tag != "Player") && trashbagScript.isStacked == true)
        // {
        //     trashbagStackManager.stackCount--;
        //     trashbagScript.isStacked = false;
        //     trashbag.tag = "Trashbag";
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     Debug.Log("EXITED");
    //     if ((other.gameObject.tag == "TrashbagStacked" || other.gameObject.tag == "Player"))
    //     {
    //         Debug.Log("EXITED CONDITIONALLY");
    //         trashbagStackManager.stackCount--;
    //         trashbagScript.isStacked = false;
    //         trashbag.tag = "Trashbag";
    //     }
    // }
}
