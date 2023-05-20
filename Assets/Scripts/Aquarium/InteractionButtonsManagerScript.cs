using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionButtonsManagerScript : MonoBehaviour
{
    Button achievementsButton;
    Button patButton;
    Button talkButton;
    Button almanacButton;

    GameObject almanacPanel;
    GameObject achievementsPanel;

    void Start()
    {
        achievementsButton = GameObject.Find("AchievementsButton").GetComponent<Button>();
        patButton = GameObject.Find("PatButton").GetComponent<Button>();
        talkButton = GameObject.Find("TalkButton").GetComponent<Button>();
        almanacButton = GameObject.Find("AlmanacButton").GetComponent<Button>();

        almanacPanel = GameObject.Find("AlmanacPanel");
        achievementsPanel = GameObject.Find("AchievementsPanel");

        AddListeners();
    }

    void AddListeners()
    {
        achievementsButton.onClick.AddListener(OpenAchievementsPanel);
        almanacButton.onClick.AddListener(OpenAlmanacPanel);
    }

    public void OpenAlmanacPanel()
    {
        Debug.Log("ALMANAC");
        almanacPanel.SetActive(true);
    }

    public void OpenAchievementsPanel()
    {
        Debug.Log("ACHIEVEMENTSuuuuuu");
        achievementsPanel.SetActive(true);
    }
}
