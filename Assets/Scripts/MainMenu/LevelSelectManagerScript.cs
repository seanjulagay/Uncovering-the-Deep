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

    int selectedZone; // 0 = euphotic, 1 = dysphotic, 2 = aphotic
    int selectedLevel;

    // =========== ZONE SELECT =========== //

    public void InitializeZoneButtons()
    {
        selectedZone = 0;
        zoneIconButton[0].GetComponent<Image>().sprite = zoneIconSpriteSel[0];
    }

    public void UpdateZonePanel(int index)
    {
        selectedZone = index;
        Debug.Log("Pressed button: " + selectedZone);
        for (int i = 0; i < zoneIconButton.Count; i++)
        {
            zoneIconButton[i].GetComponent<Image>().sprite = zoneIconSprite[i];
        }

        zoneIconButton[index].GetComponent<Image>().sprite = zoneIconSpriteSel[index];
    }

    public void ZonePlayClicked()
    {
        InitializeLevelButtons();
    }

    // =========== LEVEL SELECT =========== //

    public void InitializeLevelButtons()
    {
        for (int i = 0; i < 6; i++)
        { // clear all
            levelIconButton[i].GetComponent<Image>().sprite = levelIconSprite[0];
            levelIconButton[i].transform.Find("LevelStars").GetComponent<Image>().sprite = starIconSprite[0];
        }

        for (int i = 0; i < 6; i++)
        {

        }
    }
}
