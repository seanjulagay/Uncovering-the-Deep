using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneDataHandler : MonoBehaviour
{
    public static UserData activeUser = new UserData();
    public int rawLevelVal = 0;

    public static bool transferTempData = false;

    public static bool showMapFlag = false;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            MenuTransferData();
        }
    }

    void Update()
    {
        Debug.Log("USERNAME: " + activeUser.username);
        Debug.Log("CURRENT ZONE: " + activeUser.currentZone);
        Debug.Log("CURRENT LEVEL: " + activeUser.currentLevel);

        if (transferTempData == true)
        {
            TransferTempData();
            transferTempData = false;
        }
    }

    public static void MenuTransferData()
    {
        activeUser.userID = ProfileManagerScript.activeUser.userID;
        activeUser.userExists = ProfileManagerScript.activeUser.userExists;
        activeUser.username = ProfileManagerScript.activeUser.username;
        activeUser.iconID = ProfileManagerScript.activeUser.iconID;

        activeUser.musicOn = ProfileManagerScript.activeUser.musicOn;
        activeUser.soundOn = ProfileManagerScript.activeUser.soundOn;

        activeUser.isTutorialFinished = ProfileManagerScript.activeUser.isTutorialFinished;
        activeUser.isFirstRun = ProfileManagerScript.activeUser.isFirstRun;
        activeUser.currentZone = ProfileManagerScript.activeUser.currentZone;
        activeUser.currentLevel = ProfileManagerScript.activeUser.currentLevel;

        activeUser.levelStars = ProfileManagerScript.activeUser.levelStars;
        activeUser.levelBestTime = ProfileManagerScript.activeUser.levelBestTime;

        activeUser.isInteractable = ProfileManagerScript.activeUser.isInteractable;
        activeUser.lastInteractionTime = ProfileManagerScript.activeUser.lastInteractionTime;
        activeUser.interactionLevel = ProfileManagerScript.activeUser.interactionLevel;

        activeUser.hasUnlockedAchievement = ProfileManagerScript.activeUser.hasUnlockedAchievement;
        activeUser.hasUnlockedAlmanacAnimal = ProfileManagerScript.activeUser.hasUnlockedAlmanacAnimal;
        activeUser.hasUnlockedAlmanacTrash = ProfileManagerScript.activeUser.hasUnlockedAlmanacTrash;

        activeUser.endlessHighScore = ProfileManagerScript.activeUser.endlessHighScore;
    }

    public static void TransferTempData()
    {
        Debug.Log("Transfertempdata");
        ProfileManagerScript.activeUser.userID = activeUser.userID;
        ProfileManagerScript.activeUser.userExists = activeUser.userExists;
        ProfileManagerScript.activeUser.username = activeUser.username;
        ProfileManagerScript.activeUser.iconID = activeUser.iconID;

        ProfileManagerScript.activeUser.musicOn = activeUser.musicOn;
        ProfileManagerScript.activeUser.soundOn = activeUser.soundOn;

        ProfileManagerScript.activeUser.isTutorialFinished = activeUser.isTutorialFinished;
        ProfileManagerScript.activeUser.isFirstRun = activeUser.isFirstRun;
        ProfileManagerScript.activeUser.currentZone = activeUser.currentZone;
        ProfileManagerScript.activeUser.currentLevel = activeUser.currentLevel;

        ProfileManagerScript.activeUser.levelStars = activeUser.levelStars;
        ProfileManagerScript.activeUser.levelBestTime = activeUser.levelBestTime;

        ProfileManagerScript.activeUser.isInteractable = activeUser.isInteractable;
        ProfileManagerScript.activeUser.lastInteractionTime = activeUser.lastInteractionTime;
        ProfileManagerScript.activeUser.interactionLevel = activeUser.interactionLevel;

        ProfileManagerScript.activeUser.hasUnlockedAchievement = activeUser.hasUnlockedAchievement;
        ProfileManagerScript.activeUser.hasUnlockedAlmanacAnimal = activeUser.hasUnlockedAlmanacAnimal;
        ProfileManagerScript.activeUser.hasUnlockedAlmanacTrash = activeUser.hasUnlockedAlmanacTrash;

        ProfileManagerScript.activeUser.endlessHighScore = activeUser.endlessHighScore;

        ProfileManagerScript.SerializeJson();
        Debug.Log("Transferred temp data to central database");
    }

    public static void FinishedLevel(int zone, int level)
    {
        Debug.Log("FinishedLevel" + zone + " " + level);

        // Latest level updater
        if (zone == activeUser.currentZone && level == activeUser.currentLevel)
        {
            Debug.Log("Currently on the latest player level");
            if (zone < 2)
            {
                if (level == 0)
                {
                    activeUser.currentLevel = 1;
                }
                else if (level == 1)
                {
                    Debug.Log("New zone unlocked!");
                    activeUser.currentLevel = 0;
                    activeUser.currentZone++;
                }
            }
            else
            {
                if (activeUser.currentZone == 2)
                {
                    if (activeUser.currentLevel == 0)
                    {
                        activeUser.currentLevel = 1;
                    }
                }
            }
        }
        transferTempData = true;
    }
}
