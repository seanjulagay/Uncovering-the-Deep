using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManagerScript : MonoBehaviour
{
    const int usersCount = 6;

    public static int userID;
    public static string username;
    public static int iconID;
    public static bool isTutorialFinished;
    public static bool isFirstRun;
    public static int currentPlayerLevel;

    public static UserData[] userData = new UserData[usersCount];

    public static UserData activeUser;

    void Awake()
    {
        DeserializeJson();

        CheckForBlankProfiles();

        InitializeActiveUser();
    }

    public static void SerializeJson() // save class values to json
    {
        userData[activeUser.userID] = activeUser;

        string arrToJson = JsonHelper.ToJson(userData, true);

        Debug.Log("SERIALIZING JSON " + arrToJson);

        File.WriteAllText(Application.dataPath + "/Data/UserData.json", arrToJson);
    }

    public static void DeserializeJson() // turn json to class values
    {
        Debug.Log("DESERIALIZING JSON");

        string jsonToArr = File.ReadAllText(Application.dataPath + "/Data/UserData.json");

        userData = JsonHelper.FromJson<UserData>(jsonToArr);
    }

    public static void FlushData()
    {
        DeserializeJson();

        Debug.Log("FLUSHED DATA");

        userData = new UserData[usersCount];
        for (int i = 0; i < 6; i++)
        {
            userData[i] = new UserData();
            userData[i].userID = i;
        }

        userData[0].userExists = true;
        PlayerPrefs.DeleteAll();

        SerializeJson();
    }

    public static void PrintData()
    {
        string arrToJson = JsonHelper.ToJson(userData, true);
        Debug.Log("PRINTING DATA " + arrToJson);
    }

    public static void StoreActiveUserID()
    {
        PlayerPrefs.SetInt("activeUserID", activeUser.userID);
    }

    public static void InitializeActiveUser()
    {
        int activeUserID = PlayerPrefs.GetInt("activeUserID");

        if (userData[activeUserID].userExists == false)
        {
            activeUser = userData[0];
        }
        else
        {
            activeUser = userData[activeUserID];
        }

        Debug.Log("Active user: " + activeUser.userID);
    }

    public void CheckForBlankProfiles()
    {
        if (userData[0].userExists == false)
        {
            userData[0] = new UserData();
            userData[0].userExists = true;
            userData[0].username = "Player";
            userData[0].userID = 0;
        }
    }
}
