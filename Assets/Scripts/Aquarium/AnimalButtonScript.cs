using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class AnimalButtonScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    AnimalUnlockManagerScript animalUnlockManagerScript;
    NotificationsManager notificationsManager;
    AquariumDialogueManagerScript aquariumDialogueManagerScript;
    AnimalDialogueScript animalDialogueScript;
    InteractionButtonsManagerScript interactionButtonsManagerScript;
    AnimalInteractScript animalInteractScript;
    SpriteRenderer spriteRenderer;
    public Color hoverColor;

    GameObject affectionPanel;

    void Awake()
    {
        affectionPanel = GameObject.Find("AffectionPanel");
    }

    void Start()
    {
        animalUnlockManagerScript = GameObject.Find("AnimalUnlockManager").GetComponent<AnimalUnlockManagerScript>();
        notificationsManager = GameObject.Find("NotificationsManager").GetComponent<NotificationsManager>();
        aquariumDialogueManagerScript = GameObject.Find("DialogueManager").GetComponent<AquariumDialogueManagerScript>();
        animalDialogueScript = gameObject.GetComponent<AnimalDialogueScript>();
        interactionButtonsManagerScript = GameObject.Find("InteractionButtonsManager").GetComponent<InteractionButtonsManagerScript>();
        animalInteractScript = gameObject.GetComponent<AnimalInteractScript>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log("my object: " + gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        spriteRenderer.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        spriteRenderer.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("CLICKED " + gameObject);
        if (interactionButtonsManagerScript.animalInteractionMode == 1) // interact
        {
            Debug.Log("CALC: " + (animalInteractScript.lastInteractionTime.AddDays(1) - DateTime.Today));
            if ((animalInteractScript.lastInteractionTime.AddDays(1) - DateTime.Today) > TimeSpan.Zero) // already interacted
            {
                aquariumDialogueManagerScript.AlreadyInteractedDialogue(gameObject);
                Debug.Log("ALREADY INTERACTED");
            }
            else // interacting
            {
                aquariumDialogueManagerScript.InteractDialogue(gameObject);
                animalInteractScript.lastInteractionTime = DateTime.Now;
                animalInteractScript.animalAffection++;
                Debug.Log("INTERACTING");
            }
            affectionPanel.SetActive(true);
            animalInteractScript.UpdateAffectionBar();
            animalUnlockManagerScript.SaveInteractionStatus();
            notificationsManager.OceansStewardessAchievement();
        }
        else if (interactionButtonsManagerScript.animalInteractionMode == 2) // talk
        {
            aquariumDialogueManagerScript.ImportDialogueData(animalDialogueScript.animalName, gameObject.GetComponent<SpriteRenderer>().sprite, animalDialogueScript.animalDialogue[UnityEngine.Random.Range(0, animalInteractScript.animalAffection)]);
        }
    }
}
