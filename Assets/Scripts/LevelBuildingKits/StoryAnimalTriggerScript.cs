using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryAnimalTriggerScript : MonoBehaviour
{
    public string animalDialogue;
    UIManagerScript uiManagerScript;

    void Start()
    {
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     uiManagerScript.UpdateDialogueUI(animalDialogue);
    // }

    void OnTriggerStay2D(Collider2D other)
    {
        uiManagerScript.UpdateDialogueUI(animalDialogue);
    }
}
