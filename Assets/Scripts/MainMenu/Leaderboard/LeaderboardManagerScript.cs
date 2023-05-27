using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LeaderboardManagerScript : MonoBehaviour
{
    CreateEditProfileManagerScript createEditProfileManagerScript;

    public GameObject leaderboardItemPf;

    public Sprite[] medalSprites;

    UserData[] userData;

    GameObject leaderboardItems;

    GameObject leaderboardItem;
    Image medalImage;
    Image playerImage;
    TMP_Text playerName;
    TMP_Text playerScore;

    void Start()
    {
        createEditProfileManagerScript = GameObject.Find("CreateEditProfileManager").GetComponent<CreateEditProfileManagerScript>();

        leaderboardItems = GameObject.Find("LeaderboardItems");

        // DisplayLeaderboard();
        // SortLeaderboard();
        // DisplayLeaderboard();
    }

    void SnapshotData()
    {
        userData = new UserData[ProfileManagerScript.userData.Length];
        Array.Copy(ProfileManagerScript.userData, userData, ProfileManagerScript.userData.Length);
    }

    void SortLeaderboard()
    {
        UserData temp;

        for (int i = 0; i < userData.Length; i++)
        {
            for (int j = 0; j < userData.Length - 1; j++)
            {
                if (userData[j].endlessHighScore < userData[j + 1].endlessHighScore)
                {
                    temp = userData[j + 1];
                    userData[j + 1] = userData[j];
                    userData[j] = temp;
                }
            }
        }
    }

    void DisplayLeaderboard()
    {
        Debug.Log("DISPLAYLEADERBOARD");
        for (int i = 0; i < userData.Length; i++)
        {
            Debug.Log("USER: " + userData[i].userID + " " + userData[i].endlessHighScore);
        }
    }

    public void InitializeLeaderboard()
    {
        SnapshotData();
        SortLeaderboard();

        for (int i = 0; i < userData.Length; i++)
        {
            if (userData[i].userExists == true)
            {
                InstantiateLeaderboardItem(i);
            }
        }
    }

    public void ClearLeaderboard()
    {
        foreach (Transform child in GameObject.Find("LeaderboardItems").transform)
        {
            Debug.Log("Destroying Child " + child.gameObject.name);
            Destroy(child.gameObject);
        }
    }

    void InstantiateLeaderboardItem(int index)
    {
        GameObject leaderboardItem = Instantiate(leaderboardItemPf, transform.position, Quaternion.identity, GameObject.Find("LeaderboardItems").transform);

        Image medalImage = leaderboardItem.transform.Find("MedalImage").GetComponent<Image>();
        Image playerImage = leaderboardItem.transform.Find("PlayerImage").GetComponent<Image>();
        TMP_Text playerName = leaderboardItem.transform.Find("PlayerName").GetComponent<TMP_Text>();
        TMP_Text scoreText = leaderboardItem.transform.Find("ScoreText").GetComponent<TMP_Text>();

        medalImage.sprite = medalSprites[index];
        playerImage.sprite = createEditProfileManagerScript.iconSprites[userData[index].iconID];
        playerName.text = userData[index].username;
        scoreText.text = userData[index].endlessHighScore.ToString();
    }
}
