using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueTriggerScript : MonoBehaviour
{
    DialogueTriggerManagerScript dialogueTriggerManagerScript;
    public int dialogueIndex = 0;
    public string dialogueText;

    void Start()
    {
        dialogueTriggerManagerScript = GameObject.Find("DialogueTriggerManager").GetComponent<DialogueTriggerManagerScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("DialogueTriggered");
        dialogueTriggerManagerScript.ChangeDialogue(dialogueIndex);
    }

    void OnValidate() // FOR EDITOR PURPOSES ONLY !!!!!!
    {
        string dialogueJsonPath = "/Data/LevelDialogueData/" + "DemoLevel" + "/LevelDialogueData.json";
        string jsonString = File.ReadAllText(Application.dataPath + dialogueJsonPath);

        LevelDialogueClass levelDialogueClass = JsonUtility.FromJson<LevelDialogueClass>(jsonString);

        dialogueText = levelDialogueClass.dialogue[dialogueIndex];
    }
}
