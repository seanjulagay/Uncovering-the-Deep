using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManagerScript : MonoBehaviour
{
    GameObject trashbagsParent;
    public GameObject[] trashbagPFs;

    public GameObject startPoint, finishPoint, returnPoint;
    Rigidbody2D startRb, finishRb;

    public GameObject checkpointObjects;
    List<GameObject> checkpointObjs = new List<GameObject>();

    public bool stackingPhase = false;
    public int checkpointCount = 0;

    void Start()
    {
        trashbagsParent = GameObject.Find("Trashbags");
        startPoint = GameObject.Find("StartPoint");
        returnPoint = GameObject.Find("ReturnPoint");
        checkpointObjects = GameObject.Find("CheckpointObjects");

        try
        {
            finishPoint = GameObject.Find("FinishPoint");
        }
        catch (NullReferenceException e)
        {
            finishPoint = null;
        }

        for (int i = 0; i < checkpointObjects.transform.childCount; i++)
        {
            checkpointObjs.Add(checkpointObjects.transform.GetChild(i).gameObject);
        }
    }

    public void CheckpointPassed()
    {
        checkpointCount++;
    }

    public void SpawnTrashbag(GameObject checkpointPad)
    {
        float trashY = checkpointPad.transform.position.y - 2.2f;

        Instantiate(trashbagPFs[UnityEngine.Random.Range(0, 2)], new Vector3(checkpointPad.transform.position.x, trashY, checkpointPad.transform.position.z), transform.rotation, trashbagsParent.transform);
    }

    public void TurnAllTrashbagsStackable()
    {
        GameObject[] trashbags = GameObject.FindGameObjectsWithTag("Trashbag");

        foreach (GameObject trashbag in trashbags)
        {
            trashbag.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
