using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrappedAnimalTriggerScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;
    public GameObject storyAnimalPrefab;
    GameObject parentObj;

    public string postRescueDialogue;
    public bool tappingMinigameOngoing = false;
    public float freeingProgress = 0;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
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
        }

        if (freeingProgress >= 10)
        {
            parentObj.SetActive(false);
            InstantiateStoryAnimal();
            gameManagerScript.animalsFreed++;
        }
    }

    void InstantiateStoryAnimal()
    {
        GameObject storyAnimal = Instantiate(storyAnimalPrefab, parentObj.transform.position, transform.rotation, GameObject.Find("StoryAnimal").transform);
        storyAnimal.transform.localScale = parentObj.transform.localScale;
        storyAnimal.GetComponent<SpriteRenderer>().sprite = parentObj.GetComponent<SpriteRenderer>().sprite;
        storyAnimal.GetComponent<SpriteRenderer>().drawMode = parentObj.GetComponent<SpriteRenderer>().drawMode;
        storyAnimal.transform.Find("StoryAnimalTrigger").GetComponent<StoryAnimalTriggerScript>().animalDialogue = postRescueDialogue;
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
