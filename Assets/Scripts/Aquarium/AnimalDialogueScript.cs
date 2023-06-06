using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDialogueScript : MonoBehaviour
{
    AquariumDialogueManagerScript aquariumDialogueManagerScript;

    public string animalName;
    [Tooltip("Separate by slashes")]
    public List<string> animalDialogue = new List<string>();

    void Start()
    {
        aquariumDialogueManagerScript = GameObject.Find("DialogueManager").GetComponent<AquariumDialogueManagerScript>();
    }

    void UpdateDialoguePanel()
    {

    }
}
