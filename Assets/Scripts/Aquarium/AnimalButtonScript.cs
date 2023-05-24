using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class AnimalButtonScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    AquariumDialogueManagerScript aquariumDialogueManagerScript;
    AnimalDialogueScript animalDialogueScript;
    InteractionButtonsManagerScript interactionButtonsManagerScript;
    AnimalInteractScript animalInteractScript;
    SpriteRenderer spriteRenderer;
    public Color hoverColor;

    void Start()
    {
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
            if ((animalInteractScript.lastInteractionTime.AddDays(1) - DateTime.Today) > TimeSpan.Zero)
            {
                aquariumDialogueManagerScript.AlreadyInteractedDialogue(gameObject);
            }
            else
            {
                aquariumDialogueManagerScript.InteractDialogue(gameObject);
                animalInteractScript.lastInteractionTime = DateTime.Now;
                animalInteractScript.interactedToday = true;
            }
        }
        else if (interactionButtonsManagerScript.animalInteractionMode == 2) // talk
        {
            aquariumDialogueManagerScript.ImportDialogueData(animalDialogueScript.animalName, gameObject.GetComponent<SpriteRenderer>().sprite, animalDialogueScript.animalDialogue);
        }
    }
}
