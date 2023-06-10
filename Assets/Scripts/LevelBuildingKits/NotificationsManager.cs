using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class NotificationsManager : MonoBehaviour
{
    GameManagerScript gameManagerScript;
    SoundsManagerScript soundsManagerScript;

    public Animator achievement;
    public GameObject achievementObj;
    public Image trophySprite;
    public TMP_Text trophyName;
    public TMP_Text trophyDesc;

    public List<string> achievementName = new List<string>();
    public List<string> achievementDesc = new List<string>();
    public List<Sprite> achievementImg = new List<Sprite>();

    int index = 0;

    bool explorerFlag = false;
    bool socializerFlag = false;
    bool deepDiverFlag = false;
    bool oceanTamerFlag = false;
    bool oceansStewardessFlag = false;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        soundsManagerScript = GameObject.Find("SoundsManager").GetComponent<SoundsManagerScript>();

        // try
        // {

        // }
        // catch (Exception e)
        // {
        //     Debug.Log(e + " IN NOTIFICATIONSMANAGER");
        // }
        achievement = GameObject.Find("AchievementUnlocked").GetComponent<Animator>();
        achievementObj = GameObject.Find("AchievementUnlocked");
        trophySprite = GameObject.Find("TrophySprite").GetComponent<Image>();
        trophyName = GameObject.Find("TrophyName").GetComponent<TMP_Text>();
        trophyDesc = GameObject.Find("TrophyDesc").GetComponent<TMP_Text>();
    }

    void Update()
    {
        ExplorerAchievement();
        SocializerAchievement();
        DeepDiverAchievement();
    }

    public void ShowAchievement()
    {
        Debug.Log("INDEX: " + index);
        trophySprite.sprite = achievementImg[index];
        trophyName.text = achievementName[index];
        trophyDesc.text = achievementDesc[index];
        achievement.enabled = true;
        soundsManagerScript.SoundVictory();
    }

    public void ExplorerAchievement()
    {
        if (explorerFlag == false)
        {
            if (SceneManager.GetActiveScene().name == "Level_1.1_Restoration")
            {
                Debug.Log("Attempting to trigger explorer achievmenet");
                if (SceneDataHandler.activeUser.hasUnlockedAchievement[0] == false)
                {
                    Debug.Log("Triggered explorer achievement");
                    SceneDataHandler.activeUser.hasUnlockedAchievement[0] = true;
                    index = Array.IndexOf(achievementName.ToArray(), "Explorer");
                    ShowAchievement();
                    explorerFlag = true;
                }
            }
        }
    }

    public void SocializerAchievement()
    {
        if (SceneDataHandler.activeUser.hasUnlockedAchievement[1] == false)
        {
            Debug.Log("SOCIALIZER: COND1");
            if (socializerFlag == false)
            {
                Debug.Log("SOCIALIZER: COND2");
                if (SceneManager.GetActiveScene().name == "Level_1.2_Exploration")
                {
                    Debug.Log("SOCIALIZER: COND3");
                    if (gameManagerScript.animalsMet == 3)
                    {
                        Debug.Log("SOCIALIZER: COND4");
                        SceneDataHandler.activeUser.hasUnlockedAchievement[1] = true;
                        index = Array.IndexOf(achievementName.ToArray(), "Socializer");
                        ShowAchievement();
                        socializerFlag = true;
                    }
                }
            }
        }
    }

    public void DeepDiverAchievement()
    {
        if (deepDiverFlag == false)
        {
            if (SceneDataHandler.activeUser.hasUnlockedAchievement[2] == false)
            {
                if (SceneManager.GetActiveScene().name == "Level_3.1_Restoration")
                {
                    SceneDataHandler.activeUser.hasUnlockedAchievement[2] = true;
                    index = Array.IndexOf(achievementName.ToArray(), "Deep Diver");
                    ShowAchievement();
                    deepDiverFlag = true;
                }
            }
        }
    }

    public void OceanTamerAchievement()
    {
        if (SceneDataHandler.activeUser.hasUnlockedAchievement[3] == false)
        {
            if (SceneManager.GetActiveScene().name == "Level_3.2_Exploration")
            {
                SceneDataHandler.activeUser.hasUnlockedAchievement[3] = true;
                index = Array.IndexOf(achievementName.ToArray(), "Ocean Tamer");
                ShowAchievement();
            }
        }
    }

    public void OceansStewardessAchievement()
    {
        if (oceansStewardessFlag == false)
        {
            if (SceneDataHandler.activeUser.hasUnlockedAchievement[4] == false)
            {
                if (SceneManager.GetActiveScene().name == "Aquarium")
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (SceneDataHandler.activeUser.interactionLevel[i] != 3)
                        {
                            return;
                        }
                    }
                    SceneDataHandler.activeUser.hasUnlockedAchievement[4] = true;
                    index = Array.IndexOf(achievementName.ToArray(), "Ocean's Stewardess");
                    ShowAchievement();
                    oceansStewardessFlag = true;
                }
            }
        }
    }

}
