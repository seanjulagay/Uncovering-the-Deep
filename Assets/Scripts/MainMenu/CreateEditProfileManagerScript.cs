using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateEditProfileManagerScript : MonoBehaviour
{
    public MenuManagerScript menuManagerScript;
    public SelectProfileManagerScript selectProfileManagerScript;

    public GameObject selectProfileOverlay;
    public GameObject createProfileOverlay;
    public GameObject editProfileOverlay;
    public GameObject nicknameTextCreate;
    public GameObject nicknameTextEdit;

    public List<Sprite> iconSprites;
    public List<Sprite> iconSpritesSelected;
    public GameObject[] iconObjectsCreate;
    public GameObject[] iconObjectsEdit;

    int selectedIconID = 0;
    int modifyingProfileIndex;

    public void SelectIconCreate(GameObject selectedObj)
    {
        foreach (GameObject iconObject in iconObjectsCreate)
        {
            iconObject.GetComponent<Image>().sprite = iconSprites[Array.IndexOf(iconObjectsCreate, iconObject)]; // Resets all icons
            if (selectedObj == iconObject)
            {
                selectedIconID = Array.IndexOf(iconObjectsCreate, iconObject);
                selectedObj.GetComponent<Image>().sprite = iconSpritesSelected[selectedIconID];
            }
        }
    }

    public void SelectIconEdit(GameObject selectedObj)
    {
        foreach (GameObject iconObject in iconObjectsEdit)
        {
            iconObject.GetComponent<Image>().sprite = iconSprites[Array.IndexOf(iconObjectsEdit, iconObject)]; // Resets all icons
            if (selectedObj == iconObject)
            {
                selectedIconID = Array.IndexOf(iconObjectsEdit, iconObject);
                selectedObj.GetComponent<Image>().sprite = iconSpritesSelected[selectedIconID];
            }
        }
    }

    public void CloseCreateEditProfileOverlay(string type)
    {
        selectProfileOverlay.SetActive(true);
        if (type == "create")
        {
            createProfileOverlay.SetActive(false);
            // createProfileOverlay.transform.Find("")
        }
        else
        {
            editProfileOverlay.SetActive(false);
        }
    }

    public void InitiateCreateProfile(int profileIndex)
    {
        modifyingProfileIndex = profileIndex;
        ClearFieldsCreate();
        createProfileOverlay.SetActive(true);
    }

    public void InitiateEditProfile(int profileIndex)
    {
        modifyingProfileIndex = profileIndex;
        ReflectSavedataOnEdit();
        editProfileOverlay.SetActive(true);
    }

    public void ClearFieldsCreate()
    {
        Debug.Log("CLEAR FIELDS CREATE");
        foreach (GameObject iconObject in iconObjectsCreate)
        {
            iconObject.GetComponent<Image>().sprite = iconSprites[Array.IndexOf(iconObjectsCreate, iconObject)];
        }

        selectedIconID = 0;
        iconObjectsCreate[0].GetComponent<Image>().sprite = iconSpritesSelected[0];
        nicknameTextCreate.GetComponent<TMP_InputField>().text = "";
    }

    public void ReflectSavedataOnEdit()
    {
        foreach (GameObject iconObject in iconObjectsEdit)
        {
            iconObject.GetComponent<Image>().sprite = iconSprites[Array.IndexOf(iconObjectsEdit, iconObject)];
        }

        iconObjectsEdit[ProfileManagerScript.userData[modifyingProfileIndex].iconID].GetComponent<Image>().sprite = iconSpritesSelected[ProfileManagerScript.userData[modifyingProfileIndex].iconID];
        nicknameTextEdit.GetComponent<TMP_InputField>().text = ProfileManagerScript.userData[modifyingProfileIndex].username;
    }

    public void SaveProfile(string type)
    {
        ProfileManagerScript.userData[modifyingProfileIndex].username = nicknameTextCreate.GetComponent<TMP_InputField>().text;
        ProfileManagerScript.userData[modifyingProfileIndex].iconID = selectedIconID;
        if (type == "create")
        {
            ProfileManagerScript.userData[modifyingProfileIndex].userExists = true;
            ProfileManagerScript.userData[modifyingProfileIndex].username = nicknameTextCreate.GetComponent<TMP_InputField>().text;
            ProfileManagerScript.activeUser = ProfileManagerScript.userData[modifyingProfileIndex];
            ProfileManagerScript.StoreActiveUserID();
        }
        else
        {
            ProfileManagerScript.userData[modifyingProfileIndex].username = nicknameTextEdit.GetComponent<TMP_InputField>().text;
        }
        ProfileManagerScript.SerializeJson();
        menuManagerScript.UpdateCurrentProfileCard();
        selectProfileManagerScript.UpdateProfileUI();
        CloseCreateEditProfileOverlay(type);
    }

    // public void SaveProfileChanges()
    // {
    //     string nicknameStr = nicknameText.GetComponent<TextMeshProUGUI>().text.ToString();
    //     if (nicknameStr.Length > 1)
    //     {
    //         ProfileManagerScript.username = nicknameStr;
    //         ProfileManagerScript.iconID = selectedIconID;
    //         menuManagerScript.UpdateCurrentProfileCard();
    //         // CloseCreateEditProfileOverlay();
    //     }
    // }
}
