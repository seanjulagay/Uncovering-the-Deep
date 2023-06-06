using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        Debug.Log("activeuser: " + activeUser.username);
        InitializeDateTimeIfEmpty();
    }

    public static void InitializeDateTimeIfEmpty()
    {
        for (int i = 0; i < activeUser.lastInteractionTime.Length; i++)
        {
            Debug.Log("Initializaton iteration");
            if (activeUser.lastInteractionTime[i] == null || activeUser.lastInteractionTime[i] == "")
            {
                Debug.Log(activeUser.username + " initialization successful");
                activeUser.lastInteractionTime[i] = "1/1/0001 12:00:00 AM";
            }
        }

        SerializeJson();
    }

    public static void SerializeJson() // save class values to json
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            activeUser = SceneDataHandler.activeUser;
            Debug.Log("Accessing SceneDataHandler from ProfileManagerScript");
        }

        userData[activeUser.userID] = activeUser;

        string arrToJson = JsonHelper.ToJson(userData, true);

        Debug.Log("SERIALIZING JSON " + arrToJson);

        File.WriteAllText(Application.streamingAssetsPath + "/Data/UserData.json", arrToJson);
    }

    public static void DeserializeJson() // turn json to class values
    {
        Debug.Log("DESERIALIZING JSON");

        string jsonToArr = File.ReadAllText(Application.streamingAssetsPath + "/Data/UserData.json");

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

        activeUser = userData[0];
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
        InitializeDateTimeIfEmpty();
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
