using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpManagerScript : MonoBehaviour
{
    public List<GameObject> levelIconButton;
    public List<Sprite> levelIconSprite;
    public List<Sprite> levelIconSpriteSel;

    int selectedLevel;

    public void InitializeHelpPanel()
    {
        selectedLevel = 0;
        levelIconButton[0].GetComponent<Image>().sprite = levelIconSpriteSel[0];
    }

    public void UpdateHelpPanel(int index)
    {
        selectedLevel = index;
        for (int i = 0; i < levelIconButton.Count; i++) // clear all icons
        {
            levelIconButton[i].GetComponent<Image>().sprite = levelIconSprite[i];
        }

        levelIconButton[selectedLevel].GetComponent<Image>().sprite = levelIconSpriteSel[selectedLevel];
    }

    public void HelpPlayClicked() {
        // TODO: SWITCH SCENE TO TUTORIAL LEVEL
    }
}
