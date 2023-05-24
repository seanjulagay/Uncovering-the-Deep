using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class AlmanacManagerEntriesScript : MonoBehaviour
{
    Button sideTrashToggle;
    Button sideAnimalsToggle;
    GameObject animalEntriesAreaGroup;
    GameObject trashEntriesAreaGroup;

    Button descAreaInGameButton;
    Button descAreaRealLifeButton;
    GameObject descAreaInGameImage;
    GameObject descAreaRealLifeImage;

    Image descAreaIGImage;
    Image descAreaRLImage;

    bool hideflag = false;

    public int sideButtonCategory = 0; // 0 = trash, 1 = animals

    void Start()
    {
        sideTrashToggle = GameObject.Find("SideTrashToggle").GetComponent<Button>();
        sideAnimalsToggle = GameObject.Find("SideAnimalsToggle").GetComponent<Button>();

        sideTrashToggle.onClick.AddListener(SwitchTrashCategory);
        sideAnimalsToggle.onClick.AddListener(SwitchAnimalsCategory);

        animalEntriesAreaGroup = GameObject.Find("AnimalEntriesAreaGroup");
        trashEntriesAreaGroup = GameObject.Find("TrashEntriesAreaGroup");

        descAreaInGameButton = GameObject.Find("DescAreaInGameButton").GetComponent<Button>();
        descAreaRealLifeButton = GameObject.Find("DescAreaRealLifeButton").GetComponent<Button>();

        descAreaInGameButton.onClick.AddListener(SwitchInGameImage);
        descAreaRealLifeButton.onClick.AddListener(SwitchRealLifeImage);

        descAreaInGameImage = GameObject.Find("DescriptionAreaInGameImage");
        descAreaRealLifeImage = GameObject.Find("DescriptionAreaRealLifeImage");

        descAreaIGImage = GameObject.Find("DescAreaIGImage").GetComponent<Image>();
        descAreaRLImage = GameObject.Find("DescAreaRLImage").GetComponent<Image>();
    }

    void Update()
    {
        if (hideflag == false)
        {
            animalEntriesAreaGroup.SetActive(false);
            descAreaRealLifeImage.SetActive(false);
            hideflag = true;
        }
    }

    public void SwitchTrashCategory()
    {
        animalEntriesAreaGroup.SetActive(false);
        trashEntriesAreaGroup.SetActive(true);
        sideButtonCategory = 0;
    }

    public void SwitchAnimalsCategory()
    {
        animalEntriesAreaGroup.SetActive(true);
        trashEntriesAreaGroup.SetActive(false);
        sideButtonCategory = 1;
    }

    public void SwitchInGameImage()
    {
        descAreaRealLifeImage.SetActive(false);
        descAreaInGameImage.SetActive(true);
        descAreaRLImage.color = Color.clear;
    }

    public void SwitchRealLifeImage()
    {
        descAreaRealLifeImage.SetActive(true);
        descAreaInGameImage.SetActive(false);
        descAreaRLImage.color = Color.white;
    }

    // Toggle trashToggle, animalsToggle;
    // Toggle inGameToggle, realLifeToggle;

    // public GameObject entryPrefab;
    // public GameObject invisibleEntryPrefab;
    // List<GameObject> entriesAreaRow = new List<GameObject>();

    // GameObject descAreaInGameImgObj;
    // GameObject descAreaRealLifeImgObj;
    // Sprite descriptionAreaInGameImage;
    // Sprite descriptionAreaRealLifeImage;
    // TMP_Text descriptionAreaTextHeader;
    // TMP_Text descriptionAreaTextBody;
    // TMP_Text descriptionAreaTextAdd1;
    // TMP_Text descriptionAreaTextAdd2;
    // TMP_Text almanacInstructions;

    // public List<string> trashEntryName = new List<string>();
    // public List<Sprite> trashEntrySprite = new List<Sprite>();
    // public List<Sprite> trashRealLifeSprite = new List<Sprite>();
    // public List<string> trashEntryDescription = new List<string>();

    // public List<string> animalEntryName = new List<string>();
    // public List<Sprite> animalEntrySprite = new List<Sprite>();
    // public List<Sprite> animalRealLifeSprite = new List<Sprite>();
    // public List<string> animalEntryDescription = new List<string>();
    // public List<string> animalEntryDepthZone = new List<string>();
    // public List<string> animalEntryClassification = new List<string>();
    // public List<string> animalEntryFunFact = new List<string>();

    // List<GameObject> entryObjs = new List<GameObject>();
    // GameObject currentEntryObj;

    // int categoryType = 0;

    // void Start()
    // {
    //     trashToggle = GameObject.Find("SideTrashToggle").GetComponent<Toggle>();
    //     animalsToggle = GameObject.Find("SideAnimalsToggle").GetComponent<Toggle>();
    //     inGameToggle = GameObject.Find("DescAreaInGameToggle").GetComponent<Toggle>();
    //     realLifeToggle = GameObject.Find("DescAreaRealLifeToggle").GetComponent<Toggle>();

    //     almanacInstructions = GameObject.Find("AlmanacInstructions").GetComponent<TMP_Text>();
    //     descAreaInGameImgObj = GameObject.Find("DescriptionAreaInGameImage");
    //     descAreaRealLifeImgObj = GameObject.Find("DescriptionAreaRealLifeImage");
    //     descriptionAreaInGameImage = GameObject.Find("DescriptionAreaInGameImage").GetComponent<Image>().sprite;
    //     descriptionAreaRealLifeImage = GameObject.Find("DescriptionAreaRealLifeImage").GetComponent<Image>().sprite;
    //     descriptionAreaTextHeader = GameObject.Find("DescriptionAreaTextHeader").GetComponent<TMP_Text>();
    //     descriptionAreaTextBody = GameObject.Find("DescriptionAreaTextBody").GetComponent<TMP_Text>();
    //     descriptionAreaTextAdd1 = GameObject.Find("DescriptionAreaTextAdd1").GetComponent<TMP_Text>();
    //     descriptionAreaTextAdd2 = GameObject.Find("DescriptionAreaTextAdd2").GetComponent<TMP_Text>();

    //     AddListeners();
    //     AddEntriesAreaRows();
    //     InitializeOnStartup();
    // }

    // void AddListeners()
    // {
    //     trashToggle.onValueChanged.AddListener(delegate { SideButtonToggleManager(0); });
    //     animalsToggle.onValueChanged.AddListener(delegate { SideButtonToggleManager(1); });
    // }

    // void DescAreaToggleBehavior()
    // {
    //     if (inGameToggle.isOn)
    //     {
    //         descAreaInGameImgObj.SetActive(true);
    //         descAreaRealLifeImgObj.SetActive(false);
    //     }
    //     else if (realLifeToggle.isOn)
    //     {
    //         descAreaInGameImgObj.SetActive(false);
    //         descAreaRealLifeImgObj.SetActive(true);
    //     }
    // }

    // void InitializeOnStartup()
    // {
    //     trashToggle.isOn = true;
    //     inGameToggle.isOn = true;

    //     SideButtonToggleManager(0);

    // }

    // void AddEntriesAreaRows()
    // {
    //     entriesAreaRow.Add(GameObject.Find("EntriesAreaRow1"));
    //     entriesAreaRow.Add(GameObject.Find("EntriesAreaRow2"));
    //     entriesAreaRow.Add(GameObject.Find("EntriesAreaRow3"));
    //     entriesAreaRow.Add(GameObject.Find("EntriesAreaRow4"));
    // }

    // public void SideButtonToggleManager(int type)
    // {
    //     if (type == 0)
    //     { // trash
    //         categoryType = type;
    //         almanacInstructions.text = "Select trash to read about it!";
    //         InstantiateTrashEntryBoxes();
    //         InitializeTrashData();
    //     }
    //     else
    //     {
    //         categoryType = type;
    //         almanacInstructions.text = "Select an animal to read about it!";
    //         InstantiateAnimalEntryBoxes();
    //         InitializeAnimalData();
    //     }
    // }

    // public void DescriptionAreaUpdateManager(GameObject entryObj)
    // {
    //     if (categoryType == 0)
    //     {
    //         UpdateTrashDescriptionArea(entryObjs.IndexOf(entryObj));
    //     }
    //     else if (categoryType == 1)
    //     {
    //         UpdateAnimalDescriptionArea(entryObjs.IndexOf(entryObj));
    //     }
    // }

    // public void UpdateTrashDescriptionArea(int entryIndex)
    // {
    //     Debug.Log("ENTRYINDEX: " + entryIndex);
    //     descriptionAreaInGameImage = trashEntrySprite[entryIndex];
    //     descriptionAreaRealLifeImage = trashRealLifeSprite[entryIndex];
    //     descriptionAreaTextHeader.text = trashEntryName[entryIndex];
    //     descriptionAreaTextBody.text = trashEntryDescription[entryIndex];
    //     descriptionAreaTextAdd1.text = null;
    //     descriptionAreaTextAdd2.text = null;
    // }

    // public void UpdateAnimalDescriptionArea(int entryIndex)
    // {
    //     descriptionAreaInGameImage = animalEntrySprite[entryIndex];
    //     descriptionAreaRealLifeImage = animalRealLifeSprite[entryIndex];
    //     descriptionAreaTextHeader.text = animalEntryName[entryIndex];
    //     descriptionAreaTextBody.text = animalEntryDescription[entryIndex];
    //     descriptionAreaTextAdd1.text = "<b>Depth Zone:</b> " + animalEntryDepthZone[entryIndex] + "<br><b>Classification:</b> " + animalEntryClassification[entryIndex];
    //     descriptionAreaTextAdd2.text = "<b>Fun Fact:</b> " + animalEntryFunFact[entryIndex];
    // }

    // // =========== INITIALIZE DATA =========== //

    // void InitializeTrashData()
    // {
    //     for (int i = 0; i < trashEntryName.Count; i++)
    //     {
    //         entryObjs[i].transform.Find("EntryText").GetComponent<TMP_Text>().text = trashEntryName[i];
    //         try
    //         {
    //             entryObjs[i].transform.Find("EntryToggle").Find("Image").GetComponent<Image>().sprite = trashEntrySprite[i];
    //         }
    //         catch (NullReferenceException e)
    //         {
    //             Debug.Log("Incomplete entry sprites list");
    //         }
    //     }
    // }

    // void InitializeAnimalData()
    // {
    //     for (int i = 0; i < animalEntryName.Count; i++)
    //     {
    //         entryObjs[i].transform.Find("EntryText").GetComponent<TMP_Text>().text = animalEntryName[i];
    //         try
    //         {
    //             entryObjs[i].transform.Find("EntryToggle").Find("Image").GetComponent<Image>().sprite = animalEntrySprite[i];
    //         }
    //         catch (NullReferenceException e)
    //         {
    //             Debug.Log("Incomplete entry sprites list");
    //         }
    //     }
    // }

    // // =========== INSTANTIATE ENTRY BOXES =========== //

    // void InstantiateTrashEntryBoxes()
    // {
    //     ClearEntryBoxes();

    //     int rowCount = (trashEntryName.Count / entriesAreaRow.Count);
    //     int lastRowObjCount = trashEntryName.Count - (rowCount * 4);
    //     if (lastRowObjCount == 0)
    //     {
    //         lastRowObjCount = 4;
    //     }
    //     // Debug.Log("lastrowObjectCount: " + lastRowObjCount);
    //     if (trashEntryName.Count % entriesAreaRow.Count != 0)
    //     {
    //         rowCount++;
    //     }
    //     // Debug.Log("rows to generate: " + rowCount);

    //     for (int currentRow = 0; currentRow < rowCount; currentRow++)
    //     {
    //         if (currentRow < rowCount - 1)
    //         {
    //             for (int i = 0; i < 4; i++)
    //             {
    //                 InstantiateEntry(currentRow);
    //             }
    //         }
    //         else
    //         {
    //             for (int i = 0; i < lastRowObjCount; i++)
    //             {
    //                 InstantiateEntry(currentRow);
    //             }
    //             for (int i = 0; i < (4 - lastRowObjCount); i++)
    //             {
    //                 InstantiateInvisible(currentRow);
    //             }
    //         }
    //     }
    // }

    // void InstantiateAnimalEntryBoxes()
    // {
    //     ClearEntryBoxes();

    //     int rowCount = (animalEntryName.Count / entriesAreaRow.Count);
    //     int lastRowObjCount = animalEntryName.Count - (rowCount * 4);
    //     if (lastRowObjCount == 0)
    //     {
    //         lastRowObjCount = 4;
    //     }
    //     // Debug.Log("lastrowObjectCount: " + lastRowObjCount);
    //     if (animalEntryName.Count % entriesAreaRow.Count != 0)
    //     {
    //         rowCount++;
    //     }
    //     // Debug.Log("rows to generate: " + rowCount);

    //     for (int currentRow = 0; currentRow < rowCount; currentRow++)
    //     {
    //         if (currentRow < rowCount - 1)
    //         {
    //             for (int i = 0; i < 4; i++)
    //             {
    //                 InstantiateEntry(currentRow);
    //             }
    //         }
    //         else
    //         {
    //             for (int i = 0; i < lastRowObjCount; i++)
    //             {
    //                 InstantiateEntry(currentRow);
    //             }
    //             for (int i = 0; i < (4 - lastRowObjCount); i++)
    //             {
    //                 InstantiateInvisible(currentRow);
    //             }
    //         }
    //     }
    // }

    // void ClearEntryBoxes()
    // {
    //     entryObjs.Clear();
    //     for (int i = 0; i < 4; i++)
    //     {
    //         for (int j = 0; j < entriesAreaRow[i].transform.childCount; j++)
    //         {
    //             Destroy(entriesAreaRow[i].transform.GetChild(j).gameObject);
    //         }
    //     }
    // }

    // void InstantiateEntry(int currentRow)
    // {
    //     currentEntryObj = Instantiate(entryPrefab, transform.position, transform.rotation, entriesAreaRow[currentRow].transform);
    //     // Debug.Log(currentEntryObj.transform.Find("EntryToggle").name);
    //     // Debug.Log("Parent: " + entriesAreaRow[currentRow].transform.parent);
    //     entryObjs.Add(currentEntryObj);
    //     currentEntryObj.transform.Find("EntryToggle").GetComponent<Toggle>().group = entriesAreaRow[currentRow].transform.parent.GetComponent<ToggleGroup>();
    //     currentEntryObj.transform.Find("EntryToggle").GetComponent<Toggle>().onValueChanged.AddListener(delegate { DescriptionAreaUpdateManager(currentEntryObj); });
    // }

    // void InstantiateInvisible(int currentRow)
    // {
    //     Instantiate(invisibleEntryPrefab, transform.position, transform.rotation, entriesAreaRow[currentRow].transform);
    // }
}
