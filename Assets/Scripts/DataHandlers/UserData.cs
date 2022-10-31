using System.Collections.Generic;
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
    public int[] levelStars = new int[15];
}