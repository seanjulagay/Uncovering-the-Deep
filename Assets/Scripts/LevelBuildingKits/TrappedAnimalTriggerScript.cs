using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrappedAnimalTriggerScript : MonoBehaviour
{
    AnimalRescueProgressBarScript animalRescueProgressBarScript;
    GameManagerScript gameManagerScript;
    GameObject animalRescuePanel;
    GameObject myDialogueTrigger;
    GameObject trappedAnimalProps;

    public bool tappingMinigameOngoing = false;
    public float freeingProgress = 0;
    public float freeingMaximum = 10f;

    bool firstStartFlags = false;

    void Awake()
    {
        animalRescuePanel = GameObject.Find("AnimalRescuePanel");
    }

    void Start()
    {
        animalRescueProgressBarScript = GameObject.Find("RescueBar").GetComponent<AnimalRescueProgressBarScript>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        myDialogueTrigger = gameObject.transform.parent.Find("DialogueTrigger").gameObject;
        trappedAnimalProps = transform.parent.Find("TrappedAnimalProps").gameObject;
    }

    void FirstStart()
    {
        if (firstStartFlags == false)
        {
            myDialogueTrigger.SetActive(false);
            animalRescuePanel.SetActive(false);
            firstStartFlags = true;
        }
    }

    void Update()
    {
        FirstStart();
        ReduceProgress();
        if (tappingMinigameOngoing == true)
        {
            StartMinigame();
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

    void StartMinigame()
    {
        animalRescuePanel.SetActive(true);

        Debug.Log("MAXIMUM: " + animalRescueProgressBarScript.maximum);

        animalRescueProgressBarScript.maximum = freeingMaximum;
        animalRescueProgressBarScript.current = freeingProgress;

        if (Input.GetKeyDown("space"))
        {
            freeingProgress += 1;
        }

        if (freeingProgress >= freeingMaximum)
        {
            trappedAnimalProps.SetActive(false);
            animalRescuePanel.SetActive(false);
            SwapDialogueTrigger();
            gameManagerScript.animalsSaved++;
            gameObject.SetActive(false);
        }
    }

    void EndMinigame()
    {

    }

    void SwapDialogueTrigger()
    {
        myDialogueTrigger.SetActive(true);
    }

    void UpdateAnimalRescueProgressBar()
    {
        animalRescuePanel.SetActive(true);

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animalRescuePanel.SetActive(true);
            tappingMinigameOngoing = true;
            UIManagerScript.activeTrappedAnimalTrigger = gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animalRescuePanel.SetActive(false);
            tappingMinigameOngoing = false;
            UIManagerScript.activeTrappedAnimalTrigger = null;
        }
    }
}
