using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueTriggerManagerScript : MonoBehaviour
{
    UIManagerScript uiManagerScript;
    public LevelDialogueClass levelDialogueClass;

    public string levelName; // Format: "/Data/LevelDialogueData/{DemoLevel}/LevelDialogueData.json"

    string currentDialogue;
    string dialogueJsonPath;

    void Start()
    {
        ProcessJson();
    }

    void ProcessJson()
    {
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        dialogueJsonPath = "/Data/LevelDialogueData/" + levelName + "/LevelDialogueData.json";
        DeserializeJson();
    }

    void DeserializeJson()
    {
        string jsonString = File.ReadAllText(Application.streamingAssetsPath + dialogueJsonPath);

        levelDialogueClass = JsonUtility.FromJson<LevelDialogueClass>(jsonString);
    }

    public void ChangeDialogue(int dialogueIndex)
    {
        // Debug.Log("Changing dialogue internally");
        currentDialogue = levelDialogueClass.dialogue[dialogueIndex];
        // uiManagerScript.UpdateDialogueUI(currentDialogue);
    }
}
