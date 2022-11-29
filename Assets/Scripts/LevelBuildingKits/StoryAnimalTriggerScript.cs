using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryAnimalTriggerScript : MonoBehaviour
{
    public string animalDialogue;
    public int animalDialgoueDecay;
    UIManagerScript uiManagerScript;

    void Start()
    {
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        uiManagerScript.UpdateDialogueUI(animalDialogue, animalDialgoueDecay);
    }
}
