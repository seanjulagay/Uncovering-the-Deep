using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AquariumButtonManagerScript : MonoBehaviour
{
    AnimalUnlockManagerScript animalUnlockManagerScript;

    Button almanacCloseButton;
    Button achievementsCloseButton;
    GameObject almanacPanel;
    GameObject achievementsPanel;
    Button backToMainMenuButton;

    void Start()
    {
        animalUnlockManagerScript = GameObject.Find("AnimalUnlockManager").GetComponent<AnimalUnlockManagerScript>();

        almanacCloseButton = GameObject.Find("AlmanacCloseButton").GetComponent<Button>();
        almanacCloseButton.onClick.AddListener(CloseAlmanac);
        almanacPanel = GameObject.Find("AlmanacPanel");

        achievementsCloseButton = GameObject.Find("AchievementsCloseButton").GetComponent<Button>();
        achievementsCloseButton.onClick.AddListener(CloseAchievements);
        achievementsPanel = GameObject.Find("AchievementsPanel");

        backToMainMenuButton = GameObject.Find("buttonBackAquarium").GetComponent<Button>();
        backToMainMenuButton.onClick.AddListener(backToMainMenu);
    }

    public void CloseAlmanac()
    {
        almanacPanel.SetActive(false);
    }

    public void CloseAchievements()
    {
        achievementsPanel.SetActive(false);
    }

    public void backToMainMenu()
    {
        animalUnlockManagerScript.SaveInteractionStatus();
        SceneManager.LoadScene("MainMenu");
    }
}
