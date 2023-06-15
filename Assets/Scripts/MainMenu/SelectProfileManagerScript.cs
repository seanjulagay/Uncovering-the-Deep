using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectProfileManagerScript : MonoBehaviour
{
    public GameObject selectProfileOverlay;
    public GameObject createProfileOverlay;
    public GameObject editProfileOverlay;
    public GameObject createEditProfileManager;
    public GameObject emptyResearcherPrefab;
    public GameObject addResearcherPrefab;
    public GameObject filledResearcherPrefab;

    public TMP_Text profileNumberText;

    public MenuManagerScript menuManagerScript;

    public List<GameObject> cardObj;
    public List<Sprite> icon;

    public List<Vector2> profilePositions;

    void Awake() // Initialize values in Awake since it executes before Start
    {
        for (int i = 0; i < 6; i++)
        {
            profilePositions.Add(cardObj[i].GetComponent<RectTransform>().anchoredPosition);
        }
    }

    public void UpdateProfileUI()
    {
        try
        {
            profileNumberText.text = "Available profile slots: " + cardObj.Count + "/6";
        }
        catch (NullReferenceException e)
        {
            profileNumberText.text = "Available profile slots: " + 0 + "/6";
        }

        for (int i = 0; i < 6; i++) // Reflect existing/non-existing profiles
        {
            int local_i = i;
            Destroy(cardObj[i]);

            if (ProfileManagerScript.userData[i].userExists == true)
            {
                cardObj[i] = Instantiate(filledResearcherPrefab, transform.position, transform.rotation, selectProfileOverlay.transform);
                cardObj[i].transform.Find("FilledResearcherName").GetComponent<TextMeshProUGUI>().text = ProfileManagerScript.userData[i].username;
                cardObj[i].transform.Find("FilledResearcherIcon").GetComponent<Image>().sprite = icon[ProfileManagerScript.userData[i].iconID];
                cardObj[i].GetComponent<RectTransform>().anchoredPosition = profilePositions[i];
                cardObj[i].transform.Find("EditResearcherButton").GetComponent<Button>().onClick.AddListener(delegate { EditProfile(local_i); });
                cardObj[i].transform.Find("DeleteResearcherButton").GetComponent<Button>().onClick.AddListener(delegate { DeleteProfilePrompt(local_i); });
                cardObj[i].GetComponent<Button>().onClick.AddListener(delegate { SetActiveUser(local_i); });
            }
            else
            {
                cardObj[i] = Instantiate(emptyResearcherPrefab, transform.position, transform.rotation, selectProfileOverlay.transform);
                cardObj[i].GetComponent<RectTransform>().anchoredPosition = profilePositions[i];
            }
        }

        for (int i = 0; i < 6; i++) // Place add profile on proper position
        {
            int local_i = i;
            if (ProfileManagerScript.userData[i].userExists == false)
            {
                Destroy(cardObj[i]);
                cardObj[i] = Instantiate(addResearcherPrefab, transform.position, transform.rotation, selectProfileOverlay.transform);
                cardObj[i].GetComponent<Button>().onClick.AddListener(delegate { AddProfile(local_i); });
                cardObj[i].GetComponent<RectTransform>().anchoredPosition = profilePositions[i];
                break;
            }
        }
    }

    public void SetActiveUser(int index)
    {
        ProfileManagerScript.activeUser = ProfileManagerScript.userData[index];
        ProfileManagerScript.StoreActiveUserID();
        Debug.Log("Set activeUser: " + ProfileManagerScript.activeUser.userID);
        menuManagerScript.UpdateCurrentProfileCard();
        SceneDataHandler.MenuTransferData();
        // Debug.Log("Active user: " + ProfileManagerScript.activeUser.username);

    }

    public void AddProfile(int index)
    {
        selectProfileOverlay.SetActive(false);
        createEditProfileManager.GetComponent<CreateEditProfileManagerScript>().InitiateCreateProfile(index);
    }

    public void EditProfile(int index)
    {
        selectProfileOverlay.SetActive(false);
        createEditProfileManager.GetComponent<CreateEditProfileManagerScript>().InitiateEditProfile(index);
    }

    public void DeleteProfilePrompt(int index)
    {
        if (index == ProfileManagerScript.activeUser.userID)
        {
            menuManagerScript.OpenActiveProfileOverlay();
        }
        else
        {
            menuManagerScript.profileBeingDeleted = index;
            menuManagerScript.OpenDeleteProfileOverlay();
        }
    }

    public void DeleteProfile(int index)
    {
        for (int i = index; i < 5; i++) // Shift profiles downward in array
        {
            ProfileManagerScript.userData[i] = ProfileManagerScript.userData[i + 1];
            ProfileManagerScript.userData[i].userID--;
        }

        ProfileManagerScript.userData[5] = new UserData();
        ProfileManagerScript.userData[5].userID = 5;

        UpdateProfileUI();
        ProfileManagerScript.SerializeJson();

        // if (ProfileManagerScript.userData[1].userExists == false) // TODO: Make UI panels for the first two conditions
        // {
        //     Debug.Log("Can't delete lone profile!");
        // }
        // else if (index == ProfileManagerScript.activeUser.userID)
        // {
        //     Debug.Log("Can't delete active user!");
        // }
        // else
        // {
        //     for (int i = index; i < 5; i++) // Shift profiles downward in array
        //     {
        //         ProfileManagerScript.userData[i] = ProfileManagerScript.userData[i + 1];
        //         ProfileManagerScript.userData[i].userID--;
        //     }

        //     ProfileManagerScript.userData[5] = new UserData();
        //     ProfileManagerScript.userData[5].userID = 5;

        //     UpdateProfileUI();
        //     ProfileManagerScript.SerializeJson();
        // }
    }
}
