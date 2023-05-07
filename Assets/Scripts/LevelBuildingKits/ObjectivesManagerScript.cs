using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectivesManagerScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;

    TMP_Text objectivesText;

    string tmpStarterText;

    public bool includeAnimalsMet;
    public bool includeAnimalsSaved;
    public bool includeTrashCollected;
    public bool includeTrashbags;

    int animalsMetMax = 0;
    int animalsSavedMax = 0;
    int trashCollectedMax = 0;
    int trashbagsMax = 0;

    int animalsMetCurrent = 0;
    int animalsSavedCurrent = 0;
    int trashCollectedCurrent = 0;
    int trashbagsCurrent = 0;

    public int conditionsActivated = 0;
    public int conditions = 0;
    public int conditionsCompleted = 0;
    bool initializedMax = false;

    bool activatedReturnPoint = false;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        objectivesText = GameObject.Find("ObjectivesContentText").GetComponent<TMP_Text>();
        tmpStarterText = objectivesText.text;

        UpdateText();
    }

    void InitializeMax()
    {
        if (includeAnimalsMet)
        {
            conditionsActivated++;
            animalsMetMax = GameObject.FindGameObjectsWithTag("StoryAnimal").Length;
        }
        if (includeAnimalsSaved)
        {
            conditionsActivated++;
            animalsSavedMax = GameObject.FindGameObjectsWithTag("TrappedAnimal").Length;
        }
        if (includeTrashCollected)
        {
            conditionsActivated++;
            conditionsActivated++; // duplicate to include trashbags condition
            trashCollectedMax = GameObject.FindGameObjectsWithTag("TrashObj").Length;
        }
    }

    void Update()
    {
        if (initializedMax == false)
        {
            InitializeMax();
            initializedMax = true;
        }
        UpdateText();
        CheckForCompleteConditions();
        animalsMetCurrent = gameManagerScript.animalsMet;
        animalsSavedCurrent = gameManagerScript.animalsSaved;
        trashCollectedCurrent = gameManagerScript.trashCount;
        trashbagsCurrent = gameManagerScript.trashbagStackCount;
    }

    public void UpdateText()
    {
        objectivesText.text = "";
        conditions = 0;
        conditionsCompleted = 0;
        if (includeAnimalsMet)
        {
            Debug.Log("Added animals met");
            AddText("Animals Met", animalsMetCurrent, animalsMetMax);
            conditions++;
            if (animalsMetCurrent >= animalsMetMax)
            {
                conditionsCompleted++;
            }
        }
        if (includeAnimalsSaved)
        {
            Debug.Log("Added animals saved");
            AddText("Animals Saved", animalsSavedCurrent, animalsSavedMax);
            conditions++;
            if (animalsSavedCurrent >= animalsSavedMax)
            {
                conditionsCompleted++;
            }
        }
        if (includeTrashCollected)
        {
            Debug.Log("Added trash collected");
            AddText("Trash Collected", trashCollectedCurrent, trashCollectedMax);
            conditions++;
            if (trashCollectedCurrent >= trashCollectedMax)
            {
                conditionsCompleted++;
            }
        }
        if (gameManagerScript.inStackingState == true)
        {
            Debug.Log("Added trashbags");
            trashbagsMax = GameObject.FindGameObjectsWithTag("Trashbag").Length + GameObject.FindGameObjectsWithTag("TrashbagStacked").Length;
            AddText("Trashbags Picked Up", trashbagsCurrent, trashbagsMax);
            conditions++;
            if (trashbagsCurrent >= trashbagsMax)
            {
                conditionsCompleted++;
            }
        }
    }

    void AddText(string str, int current, int max)
    {
        if (conditions == 0)
        {
            Debug.Log("REPLACED TMP TEXT");
            if (current >= max)
            {
                objectivesText.text = "<color=#00ff00><b>" + str + ": " + current + "/" + max + "</b></color>";
            }
            else
            {
                objectivesText.text = str + ": " + current + "/" + max;
            }
        }
        else
        {
            Debug.Log("APPENDED TMP TEXT");
            if (current >= max)
            {
                objectivesText.text += "<color=#00ff00><br><b>" + str + ": " + current + "/" + max + "</b></color>";
            }
            else
            {
                objectivesText.text += "<br>" + str + ": " + current + "/" + max;
            }
        }
    }

    void CheckForCompleteConditions()
    {
        if (activatedReturnPoint == false && (conditionsCompleted == conditionsActivated))
        {
            gameManagerScript.activateReturnPoint = true;
            activatedReturnPoint = true;
        }
    }
}
