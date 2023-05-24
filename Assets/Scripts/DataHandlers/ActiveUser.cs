using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class ActiveUser : MonoBehaviour
{
    // ACTIVE USERRRRRRRRRRRRRRR

    // USER DATA
    public static int userID;
    public static bool userExists = false;
    public static string username = "Empty";
    public static int iconID = 0;

    // USER SETTINGS
    public static bool musicOn = true;
    public static bool soundOn = true;

    // USER PROGRESS
    public static bool isTutorialFinished = false;
    public static bool isFirstRun = true;
    public static int currentZone = 0; // 0 = euphotic zone
    public static int currentLevel = 0; // 0 = level 1

    // USER STATS
    public static int[] levelStars = new int[6];
    public static int[] levelBestTime = new int[6];

    // AQUARIUM ANIMALS
    public static bool[] isInteractable = new bool[10];
    public static int[] interactionLevel = new int[10];

    // AQUARIUM DATA
    public static bool[] hasUnlockedAchievement = new bool[5];
    public static bool[] hasUnlockedAlmanacAnimal = new bool[12];
    public static bool[] hasUnlockedAlmanacTrash = new bool[9];
}