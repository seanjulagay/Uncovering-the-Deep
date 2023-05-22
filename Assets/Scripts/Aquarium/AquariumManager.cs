using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AquariumManager : MonoBehaviour
{
    GameObject almanacPanel;
    GameObject achievementsPanel;
    GameObject dialoguePanel;
    bool hidePanels = false;
    
    void Start()
    {
        almanacPanel = GameObject.Find("AlmanacPanel");
        achievementsPanel = GameObject.Find("AchievementsPanel");
        dialoguePanel = GameObject.Find("DialoguePanel");
    }

    void Update()
    {
        HidePanels();
    }

    void HidePanels()
    {
        if (hidePanels == false)
        {
            almanacPanel.SetActive(false);
            achievementsPanel.SetActive(false);
            dialoguePanel.SetActive(false);
            hidePanels = true;
        }
    }
}
