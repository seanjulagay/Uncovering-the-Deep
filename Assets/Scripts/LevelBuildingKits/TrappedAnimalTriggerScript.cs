using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappedAnimalTriggerScript : MonoBehaviour
{
    GameObject parentObj;
    public bool tappingMinigameOngoing = false;
    public float freeingProgress = 0;

    void Start()
    {
        parentObj = gameObject.transform.parent.gameObject;
    }

    void Update()
    {
        ReduceProgress();
        if (tappingMinigameOngoing == true)
        {
            StartMiniGame();
        }
    }

    void ReduceProgress()
    {
        if (freeingProgress > 0)
        {
            freeingProgress -= Time.deltaTime;
        }
        else if (freeingProgress <= 0)
        {
            freeingProgress = 0;
        }
    }

    void StartMiniGame()
    {
        if (Input.GetKeyDown("space"))
        {
            freeingProgress += 1;
            Debug.Log("Pressed Space");
        }

        if (freeingProgress >= 10)
        {
            parentObj.SetActive(false);
            GameManagerScript.animalsFreed++;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        tappingMinigameOngoing = true;
        UIManagerScript.activeTrappedAnimalTrigger = gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        tappingMinigameOngoing = false;
        UIManagerScript.activeTrappedAnimalTrigger = null;
    }
}
