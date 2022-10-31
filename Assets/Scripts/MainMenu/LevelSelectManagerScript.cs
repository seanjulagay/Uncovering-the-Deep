using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManagerScript : MonoBehaviour
{
    public List<GameObject> zoneIconButton;
    public List<Sprite> zoneIconSprite;
    public List<Sprite> zoneIconSpriteSel;

    public List<GameObject> levelIconButton;
    public List<Sprite> starIconSprite; // 0 = 0 stars, 1 = 1 star, etc.
    public List<Sprite> levelIconSprite; // 0 = locked level, 1 = level 1, etc.

    public MenuManagerScript menuManagerScript;

    int selectedZone; // 0 = euphotic, 1 = dysphotic, 2 = aphotic
    int selectedLevel;

    // =========== ZONE SELECT =========== //

    public void InitializeZoneButtons()
    {
        selectedZone = 0;
        ClearZoneIcons();
        zoneIconButton[0].GetComponent<Image>().sprite = zoneIconSpriteSel[0];
    }

    public void UpdateZonePanel(int index)
    {
        selectedZone = index;
        Debug.Log("Pressed button: " + selectedZone);
        ClearZoneIcons();

        zoneIconButton[index].GetComponent<Image>().sprite = zoneIconSpriteSel[index];
    }

    public void ClearZoneIcons()
    {
        for (int i = 0; i < zoneIconButton.Count; i++)
        {
            zoneIconButton[i].GetComponent<Image>().sprite = zoneIconSprite[i];
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

        if (ProfileManagerScript.activeUser.currentZone == selectedZone)
        { // load proper levels

        }
        
        for (int i = 0; i < ProfileManagerScript.activeUser.currentLevel; i++)
        {
            levelIconButton[i].GetComponent<Image>().sprite = levelIconSprite[i];
            levelIconButton[i].transform.Find("LevelStars").GetComponent<Image>().sprite = starIconSprite[ProfileManagerScript.activeUser.levelStars[(5 * selectedZone) + i]];
        }

        for (int i = ProfileManagerScript.activeUser.currentLevel + 1; i < 5; i++)
        { // load locked levels
            levelIconButton[i].GetComponent<Image>().sprite = levelIconSprite[0];
        }
    }
}
