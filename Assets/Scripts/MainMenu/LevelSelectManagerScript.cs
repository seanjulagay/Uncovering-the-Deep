using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManagerScript : MonoBehaviour
{
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
        Debug.Log("Pressed button: " + selectedZone);
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
        for (int i = 0; i < 5; i++)
        { // clear all
            levelIconButton[i].GetComponent<Image>().sprite = levelIconSprite[5];
            levelIconButton[i].transform.Find("LevelStars").GetComponent<Image>().sprite = starIconSprite[0];
        }

        // Load proper levels
        if (selectedZone == ProfileManagerScript.activeUser.currentZone) // if user selects current zone, load until locked levels
        {
            for (int i = 0; i <= ProfileManagerScript.activeUser.currentLevel; i++)
            { // load working buttons until user's current level
                Debug.Log("User selected current zone");
                levelIconButton[i].GetComponent<Image>().sprite = levelIconSprite[i];
                levelIconButton[i].transform.Find("LevelStars").GetComponent<Image>().sprite = starIconSprite[ProfileManagerScript.activeUser.levelStars[(5 * selectedZone) + i]];
            }

            for (int i = ProfileManagerScript.activeUser.currentLevel + 1; i < 5; i++)
            { // load locked levels
                levelIconButton[i].GetComponent<Image>().sprite = levelIconSprite[5];
            }
        }
        else if (selectedZone < ProfileManagerScript.activeUser.currentZone)
        { // if user selects previous zone, load everything
            for (int i = 0; i < 5; i++)
            {
                Debug.Log("User selected finished zone");
                levelIconButton[i].GetComponent<Image>().sprite = levelIconSprite[i];
                levelIconButton[i].transform.Find("LevelStars").GetComponent<Image>().sprite = starIconSprite[ProfileManagerScript.activeUser.levelStars[(5 * selectedZone) + i]];
            }
        }
    }
}
