using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AlmanacManagerEntriesScript : MonoBehaviour
{
    // public GameObject entryBoxPrefab;

    // GameObject entriesAreaColumn;
    // List<GameObject> entriesAreaRow = new List<GameObject>();
    // List<GameObject> entryBoxes = new List<GameObject>();
    // List<Toggle> entryToggles = new List<Toggle>();
    // Toggle activeItem;

    // void Start()
    // {
    //     entriesAreaColumn = GameObject.Find("EntriesAreaColumn");
    //     entriesAreaRow = GameObject.FindGameObjectsWithTag("EntriesAreaRow").ToList();
    //     entryBoxes = GameObject.FindGameObjectsWithTag("EntryBox").ToList();
    //     foreach (GameObject obj in entryBoxes)
    //     {
    //         entryToggles.Add(obj.GetComponent<Toggle>());
    //     }

    //     Debug.Log("entryToggles: " + entryToggles.Count);

    //     AddEntryListener();
    // }

    // void Update()
    // {
    //     // activeItem = entriesAreaColumn.GetComponent<ToggleGroup>().ActiveToggles().FirstOrDefault();
    // }

    // // void AddEntryListener()
    // // {
    // //     foreach (Toggle toggle in entryToggles)
    // //     {
    // //         toggle.onValueChanged.AddListener(UpdateEntries);
    // //     }
    // // }

    // public void UpdateEntries()
    // {
    //     foreach (Toggle toggle in entryToggles)
    //     {
    //         GameObject entryImageOutline = toggle.gameObject.transform.parent.Find("EntryImageOutline").gameObject;

    //         if (toggle.isOn == true)
    //         {
    //             entryImageOutline.SetActive(true);
    //         }
    //         else
    //         {
    //             entryImageOutline.SetActive(false);
    //         }
    //     }
    // }
}
