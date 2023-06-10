using System.Collections.Generic;
using System;
[System.Serializable]

public class UserData
{
    // USER DATA
    public int userID;
    public bool userExists = false;
    public string username = "Empty";
    public int iconID = 0;

    // USER SETTINGS
    public bool musicOn = true;
    public bool soundOn = true;

    // USER PROGRESS
    public bool isTutorialFinished = false;
    public bool isFirstRun = true;
    public int currentZone = 0; // 0 = euphotic zone
    public int currentLevel = 0; // 0 = level 1

    // USER STATS
    public int[] levelStars = new int[6];
    public int[] levelBestTime = new int[6];

    // AQUARIUM ANIMALS
    public bool[] isInteractable = new bool[10];
    public string[] lastInteractionTime = new string[10];
    public int[] interactionLevel = new int[10];

    // AQUARIUM DATA
    public bool[] hasUnlockedAchievement = new bool[5];
    public string[] achievementUnlockDate = new string[5];
    public bool[] hasUnlockedAlmanacAnimal = new bool[12];
    public bool[] hasUnlockedAlmanacTrash = new bool[9];

    // ENDLESS DATA
    public int endlessHighScore;
}