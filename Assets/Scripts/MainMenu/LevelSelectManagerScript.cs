using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectManagerScript : MonoBehaviour
{
    public List<Scene> zone1Levels;
    public List<Scene> zone2Levels;
    public List<Scene> zone3Levels;

    public List<GameObject> zoneIconButton;
    public List<Sprite> zoneIconSprite;
    public List<Sprite> zoneIconSpriteSel;
    public List<Sprite> zoneIconSpriteLocked;

    public List<GameObject> levelIconButton;
    public List<Sprite> starIconSprite; // 0 = 0 stars, 1 = 1 star, etc.
    public List<Sprite> levelIconSprite; // 0 = locked level, 1 = level 1, etc.

    public MenuManagerScript menuManagerScript;

    int selectedZone; // 0 = euphotic, 1 = dysphotic, 2 = aphotic
    int selectedLevel;
    int zoneMaxLevel;

    int numberOfLevels = 2;

    // =========== ZONE SELECT =========== //

    public void InitializeZoneButtons()
    {
        selectedZone = 0;
        UpdateZoneIcons();
        zoneIconButton[0].GetComponent<Image>().sprite = zoneIconSpriteSel[0];
    }

    public void UpdateZonePanel(int index)
    {
        selectedZone = index;
        // Debug.Log("Pressed button: " + selectedZone);
        UpdateZoneIcons();

        zoneIconButton[index].GetComponent<Image>().sprite = zoneIconSpriteSel[index];
    }

    public void UpdateZoneIcons()
    {
        for (int i = 0; i <= ProfileManagerScript.activeUser.currentZone; i++)
        {
            int local_i = i;
            zoneIconButton[i].GetComponent<Button>().onClick.RemoveAllListeners();
            zoneIconButton[i].GetComponent<Image>().sprite = zoneIconSprite[i];
            zoneIconButton[i].GetComponent<Button>().onClick.AddListener(delegate { UpdateZonePanel(local_i); });
        }

        for (int i = ProfileManagerScript.activeUser.currentZone + 1; i < 3; i++)
        {
            zoneIconButton[i].GetComponent<Image>().sprite = zoneIconSpriteLocked[i];
        }
    }

    public void ZonePlayClicked()
    {
        menuManagerScript.SwapToLevelOverlay();
        InitializeLevelButtons();
    }

    // =========== LEVEL SELECT =========== //

    public void InitializeLevelButtons()
    {
        Debug.Log("INITIALIZELEVELBUTTONS");
        for (int i = 0; i < numberOfLevels; i++)
        { // clear all
            levelIconButton[i].GetComponent<Image>().sprite = levelIconSprite[numberOfLevels];
            levelIconButton[i].transform.Find("LevelStars").GetComponent<Image>().sprite = starIconSprite[0];
        }

        // Load proper levels
        if (selectedZone == ProfileManagerScript.activeUser.currentZone) // if user selects current zone, load until locked levels
        {
            // for (int i = 0; i <= ProfileManagerScript.activeUser.currentLevel; i++)
            for (int i = 0; i < numberOfLevels; i++)
            { // load working buttons until user's current level
                // Debug.Log("User selected current zone");
                int index = i;
                levelIconButton[index].GetComponent<Button>().onClick.AddListener(() => { LoadLevel(index); });
                Debug.Log("Added LoadLevel(" + index + ") to " + levelIconButton[i].name);
                levelIconButton[i].GetComponent<Image>().sprite = levelIconSprite[i];
                levelIconButton[i].transform.Find("LevelStars").GetComponent<Image>().sprite = starIconSprite[ProfileManagerScript.activeUser.levelStars[(numberOfLevels * selectedZone) + i]];
                Debug.Log("Stars for level " + levelIconButton[i].name + " is " + ProfileManagerScript.activeUser.levelStars[index] + ", assigning " + starIconSprite[ProfileManagerScript.activeUser.levelStars[index]].name);
            }

            for (int i = ProfileManagerScript.activeUser.currentLevel + 1; i < numberOfLevels; i++)
            { // load locked levels
                int index = i;
                levelIconButton[i].GetComponent<Image>().sprite = levelIconSprite[numberOfLevels];
                levelIconButton[index].GetComponent<Button>().onClick.RemoveAllListeners();
                Debug.Log("Removed LoadLevel(" + index + ") from " + levelIconButton[index].name);
            }
        }
        else if (selectedZone < ProfileManagerScript.activeUser.currentZone)
        { // if user selects previous zone, load everything
            for (int i = 0; i < numberOfLevels; i++)
            {
                // Debug.Log("User selected finished zone");
                int index = i;
                levelIconButton[index].GetComponent<Button>().onClick.AddListener(() => { LoadLevel(index); });
                levelIconButton[i].GetComponent<Image>().sprite = levelIconSprite[i];
                levelIconButton[i].transform.Find("LevelStars").GetComponent<Image>().sprite = starIconSprite[ProfileManagerScript.activeUser.levelStars[(numberOfLevels * selectedZone) + i]];
            }
        }
    }

    public void LoadLevel(int level)
    {
        selectedLevel = level;
        Debug.Log("selectedZone: " + selectedZone + " selectedLevel: " + selectedLevel + " LEVEL: " + level);

        if (selectedZone == 0)
        {
            if (selectedLevel == 0)
            {
                Debug.Log("LEVEL 1");
                SceneManager.LoadScene("Level_1.1_Restoration");
            }
            else
            {
                Debug.Log("LEVEL 2");
                SceneManager.LoadScene("Level_1.2_Exploration");
            }
        }
        else if (selectedZone == 1)
        {
            if (selectedLevel == 0)
            {
                SceneManager.LoadScene("Level_2.1_Restoration");
            }
            else
            {
                SceneManager.LoadScene("Level_2.2_Exploration");
            }
        }
        else
        {
            if (selectedLevel == 0)
            {
                SceneManager.LoadScene("Level_3.1_Restoration");
            }
            else
            {
                SceneManager.LoadScene("Level_3.2_Exploration");
            }
        }
    }
}
