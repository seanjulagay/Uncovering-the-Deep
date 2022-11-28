using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManagerScript : MonoBehaviour
{
    public GameObject trashbagsParent;
    public GameObject trashbagPF;

    public GameObject startPoint, finishPoint;
    Rigidbody2D startRb, finishRb;

    public GameObject checkpointObjects;
    List<GameObject> checkpointObjs = new List<GameObject>();

    public bool stackingPhase = false;
    public int checkpointCount = 0;

    void Start()
    {
        for (int i = 0; i < checkpointObjects.transform.childCount; i++)
        {
            checkpointObjs.Add(checkpointObjects.transform.GetChild(i).gameObject);
        }
    }

    public void CheckpointPassed()
    {
        checkpointCount++;
    }

    public void SpawnTrashbag(Vector3 checkpointPadPos)
    {
        Instantiate(trashbagPF, checkpointPadPos, transform.rotation, trashbagsParent.transform);
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
