using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EntryBoxScript : MonoBehaviour
{
    AlmanacManagerEntriesScript almanacManagerEntriesScript;

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

    void Start()
    {
        almanacManagerEntriesScript = GameObject.Find("AlmanacManager").GetComponent<AlmanacManagerEntriesScript>();

        entryName = transform.Find("EntryText").GetComponent<TMP_Text>().text;
        entrySprite = transform.Find("EntryButton").Find("Image").GetComponent<Image>().sprite;

        descAreaInGameImage = GameObject.Find("DescAreaIGImage").GetComponent<Image>();
        descAreaRealLifeImage = GameObject.Find("DescAreaRLImage").GetComponent<Image>();
        descAreaTextHeader = GameObject.Find("DescriptionAreaTextHeader").GetComponent<TMP_Text>();
        descAreaTextDescription = GameObject.Find("DescriptionAreaTextBody").GetComponent<TMP_Text>();
        descAreaTextAdd1 = GameObject.Find("DescriptionAreaTextAdd1").GetComponent<TMP_Text>();
        descAreaTextAdd2 = GameObject.Find("DescriptionAreaTextAdd2").GetComponent<TMP_Text>();

        gameObject.transform.Find("EntryButton").GetComponent<Button>().onClick.AddListener(delegate { UpdateDescriptionArea(); });
    }

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
        else
        {
            descAreaTextAdd1.text = "<b>Depth Zone:</b> " + animalDepthZone + "<br><b>Classification:</b> " + animalClassification;
            descAreaTextAdd2.text = "";
        }
    }
}
