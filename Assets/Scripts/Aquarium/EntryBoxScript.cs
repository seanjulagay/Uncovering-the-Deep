using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EntryBoxScript : MonoBehaviour
{
    AlmanacManagerEntriesScript almanacManagerEntriesScript;

    [Tooltip("0 = ALMANAC, 1 = ACHIEVEMENTS")]
    public int type = 0;
    public bool isUnlocked = false;
    string entryName;
    Sprite entrySprite;
    public Sprite realLifeImage;
    public string entryDescription;
    public string animalDepthZone;
    public string animalClassification;
    public string animalFunFact;
    public string trashDangerTrait;

    Image descAreaInGameImage;
    Image descAreaRealLifeImage;
    TMP_Text descAreaTextHeader;
    TMP_Text descAreaTextDescription;
    TMP_Text descAreaTextAdd1;
    TMP_Text descAreaTextAdd2;

    Image achievementsAreaImage;
    TMP_Text achievementsAreaTextHeader;
    TMP_Text achievementsAreaTextDesc;
    TMP_Text achievementsAreaTextAdd1;

    void Start()
    {
        almanacManagerEntriesScript = GameObject.Find("AlmanacManager").GetComponent<AlmanacManagerEntriesScript>();

        entryName = transform.Find("EntryText").GetComponent<TMP_Text>().text;
        entrySprite = transform.Find("EntryButton").Find("Image").GetComponent<Image>().sprite;

        if (type == 0) // ALMANAC
        {
            descAreaInGameImage = GameObject.Find("DescAreaIGImage").GetComponent<Image>();
            descAreaRealLifeImage = GameObject.Find("DescAreaRLImage").GetComponent<Image>();
            descAreaTextHeader = GameObject.Find("DescriptionAreaTextHeader").GetComponent<TMP_Text>();
            descAreaTextDescription = GameObject.Find("DescriptionAreaTextBody").GetComponent<TMP_Text>();
            descAreaTextAdd1 = GameObject.Find("DescriptionAreaTextAdd1").GetComponent<TMP_Text>();
            descAreaTextAdd2 = GameObject.Find("DescriptionAreaTextAdd2").GetComponent<TMP_Text>();
            gameObject.transform.Find("EntryButton").GetComponent<Button>().onClick.AddListener(delegate { UpdateDescriptionArea(); });
        }
        else if (type == 1) // ACHIEVEMENTS
        {
            achievementsAreaImage = GameObject.Find("AchievementsAreaImage").GetComponent<Image>();
            achievementsAreaTextHeader = GameObject.Find("AchievementsAreaTextHeader").GetComponent<TMP_Text>();
            achievementsAreaTextDesc = GameObject.Find("AchievementsAreaTextBody").GetComponent<TMP_Text>();
            gameObject.transform.Find("EntryButton").GetComponent<Button>().onClick.AddListener(delegate { UpdateAchievementsArea(); });
        }
    }

    // ACHIEVEMENTS
    public void UpdateAchievementsArea()
    {
        achievementsAreaImage.sprite = entrySprite;
        achievementsAreaTextHeader.text = entryName;
        achievementsAreaTextDesc.text = entryDescription;
        // achievementsAreaTextAdd1.text = 
    }

    // ALMANAC
    public void UpdateDescriptionArea()
    {
        descAreaInGameImage.sprite = entrySprite;
        descAreaRealLifeImage.sprite = realLifeImage;
        descAreaTextHeader.text = entryName;
        descAreaTextDescription.text = entryDescription;

        if (almanacManagerEntriesScript.sideButtonCategory == 0) // trash
        {
            descAreaTextAdd1.text = "<b>Danger Trait:</b> " + trashDangerTrait;
            descAreaTextAdd2.text = "";
        }
        else // animal
        {
            // if (isUnlocked == false)
            // {
            //     Debug.Log("NOT UNLOCKED");
            //     descAreaInGameImage.color = Color.black;
            //     descAreaRealLifeImage.color = Color.black;
            // }
            // else
            // {
            //     Debug.Log("UNLOCKED");
            //     descAreaInGameImage.color = Color.white;
            //     descAreaRealLifeImage.color = Color.white;
            // }

            if (isUnlocked == false)
            {
                almanacManagerEntriesScript.unlocked = false;
                descAreaInGameImage.color = Color.black;
                descAreaRealLifeImage.color = Color.black;
            }
            else
            {
                almanacManagerEntriesScript.unlocked = true;
                descAreaInGameImage.color = Color.white;
                descAreaRealLifeImage.color = Color.white;
            }
            descAreaTextAdd1.text = "<br><b>Depth Zone:</b> " + animalDepthZone;
            descAreaTextAdd2.text = "<br><b>Fun Fact:</b> " + animalFunFact;
        }
    }
}
