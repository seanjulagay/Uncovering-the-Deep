using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementsManager : MonoBehaviour
{
    public List<GameObject> achievements = new List<GameObject>();
    public List<Image> images = new List<Image>();
    public List<TMP_Text> text = new List<TMP_Text>();

    public void InitializeAchievementVisibility()
    {
        for (int i = 0; i < 5; i++)
        {
            if (SceneDataHandler.activeUser.hasUnlockedAchievement[i] == false)
            {
                Debug.Log("ACHIEVEMENT: " + i + " NOT UNLOCKED");
                // achievements[i].transform.Find("Image").GetComponent<Image>().color = Color.black;
                images[i].color = Color.black;
                text[i].text = "LOCKED";
                // achievements[i].transform.Find("EntryText").GetComponent<TMP_Text>().text = "LOCKED";
            }
        }
    }
}
