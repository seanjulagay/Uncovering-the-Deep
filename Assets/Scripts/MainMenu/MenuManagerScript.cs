using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManagerScript : MonoBehaviour
{
    public GameObject mainButtonGroup;
    public GameObject gamemodeButtonGroup;
    public GameObject menuProfileCardGroup;
    public GameObject selectProfileOverlay;
    public GameObject settingsOverlay;
    public GameObject helpOverlay;
    public GameObject selectZoneOverlay;
    public GameObject selectLevelOverlay;

    public GameObject helpManager;
    public GameObject levelSelectManager;

    public GameObject profileCardName;
    public GameObject profileCardIcon;

    public GameObject musicOffButton;
    public GameObject musicOnButton;
    public GameObject soundsOffButton;
    public GameObject soundsOnButton;

    public Sprite[] icons;
    public Sprite activatedOnButton;
    public Sprite activatedOffButton;
    public Sprite deactivatedOnButton;
    public Sprite deactivatedOffButton;

    public void Start()
    {
        UpdateCurrentProfileCard();
        UpdateSettingsOverlay();
    }

    // =========== MAIN BUTTON GROUP =========== //

    public void MainPlay()
    {
        mainButtonGroup.SetActive(false);
        gamemodeButtonGroup.SetActive(true);
    }

    // =========== GAMEMODE BUTTON GROUP =========== //

    public void GameModeBack()
    {
        mainButtonGroup.SetActive(true);
        gamemodeButtonGroup.SetActive(false);
    }

    public void OpenZoneOverlay()
    {
        selectZoneOverlay.SetActive(true);
        levelSelectManager.GetComponent<LevelSelectManagerScript>().InitializeZoneButtons();
    }

    // =========== SIDE BUTTON GROUP =========== //
    public void OpenSettings()
    {
        settingsOverlay.SetActive(true);
    }

    // =========== MENU PROFILE CARD GROUP =========== //
    public void OpenSelectProfileOverlay()
    {
        selectProfileOverlay.SetActive(true);
    }

    public void UpdateCurrentProfileCard()
    {
        profileCardName.GetComponent<TextMeshProUGUI>().text = ProfileManagerScript.activeUser.username;
        profileCardIcon.GetComponent<Image>().sprite = icons[ProfileManagerScript.activeUser.iconID];
    }

    // =========== SELECT PROFILE OVERLAY =========== //
    public void CloseSelectProfileOverlay()
    {
        selectProfileOverlay.SetActive(false);
    }

    // =========== SELECT ZONE OVERLAY =========== //
    public void CloseZoneOverlay()
    {
        selectZoneOverlay.SetActive(false);
    }

    public void SwapToLevelOverlay()
    {
        selectZoneOverlay.SetActive(false);
        selectLevelOverlay.SetActive(true);
    }

    // =========== SELECT LEVEL OVERLAY =========== //
    public void CloseLevelOverlay()
    {
        selectLevelOverlay.SetActive(false);
        selectZoneOverlay.SetActive(true);
        levelSelectManager.GetComponent<LevelSelectManagerScript>().InitializeZoneButtons();
    }

    // =========== SETTINGS OVERLAY =========== //

    public void UpdateSettingsOverlay()
    {
        if (ProfileManagerScript.activeUser.musicOn == true)
        {
            musicOffButton.GetComponent<Image>().sprite = deactivatedOffButton;
            musicOnButton.GetComponent<Image>().sprite = activatedOnButton;
        }
        else
        {
            musicOffButton.GetComponent<Image>().sprite = activatedOffButton;
            musicOnButton.GetComponent<Image>().sprite = deactivatedOnButton;
        }

        if (ProfileManagerScript.activeUser.soundOn == true)
        {
            soundsOffButton.GetComponent<Image>().sprite = deactivatedOffButton;
            soundsOnButton.GetComponent<Image>().sprite = activatedOnButton;
        }
        else
        {
            soundsOffButton.GetComponent<Image>().sprite = activatedOffButton;
            soundsOnButton.GetComponent<Image>().sprite = deactivatedOnButton;
        }
    }

    public void CloseSettings()
    {
        settingsOverlay.SetActive(false);
    }

    public void ToggleMusic()
    {
        if (ProfileManagerScript.activeUser.musicOn == false)
        {
            // SettingsManagerScript.musicOn = true;
            ProfileManagerScript.activeUser.musicOn = true;
            ProfileManagerScript.SerializeJson();
            musicOffButton.GetComponent<Image>().sprite = deactivatedOffButton;
            musicOnButton.GetComponent<Image>().sprite = activatedOnButton;
        }
        else
        {
            ProfileManagerScript.activeUser.musicOn = false;
            ProfileManagerScript.SerializeJson();
            musicOffButton.GetComponent<Image>().sprite = activatedOffButton;
            musicOnButton.GetComponent<Image>().sprite = deactivatedOnButton;
        }
    }

    public void ToggleSounds()
    {
        if (ProfileManagerScript.activeUser.soundOn == false)
        {
            // SettingsManagerScript.soundsOn = true;
            ProfileManagerScript.activeUser.soundOn = true;
            ProfileManagerScript.SerializeJson();
            soundsOffButton.GetComponent<Image>().sprite = deactivatedOffButton;
            soundsOnButton.GetComponent<Image>().sprite = activatedOnButton;
        }
        else
        {
            ProfileManagerScript.activeUser.soundOn = false;
            ProfileManagerScript.SerializeJson();
            soundsOffButton.GetComponent<Image>().sprite = activatedOffButton;
            soundsOnButton.GetComponent<Image>().sprite = deactivatedOnButton;
        }
    }

    // =========== HELP OVERLAY =========== //
    public void OpenHelpOverlay()
    {
        if (ProfileManagerScript.activeUser.isTutorialFinished == false)
        {
            // TODO: Popup telling user to finish initial levels first
            Debug.Log("Finish initial levels first!");
        }
        else
        {
            helpOverlay.SetActive(true);
            helpManager.GetComponent<HelpManagerScript>().InitializeHelpPanel();
        }
    }

    public void CloseHelpOverlay()
    {
        helpOverlay.SetActive(false);
    }
}
