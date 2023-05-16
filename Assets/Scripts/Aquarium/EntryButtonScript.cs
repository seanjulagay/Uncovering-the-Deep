using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryButtonScript : MonoBehaviour
{
    public void UpdateEntryButtonGraphics()
    {
        Debug.Log("Hello World!");
    }
    // GameObject myObj;
    // Toggle myToggle;

    // void Start()
    // {
    //     myObj = gameObject;
    //     myToggle = gameObject.GetComponent<Toggle>();
    //     myToggle.onValueChanged.AddListener(UpdateEntryButtonGraphics);
    // }

    // public void UpdateEntryButtonGraphics()
    // {
    //     Debug.Log("Hello world!");
    // }

    // EntriesAreaGroupScript entriesAreaGroupScript;
    // Image entryImageOutline;
    // Toggle myToggle;

    // void Start()
    // {
    //     entriesAreaGroupScript = GameObject.Find("EntriesAreaGroup").GetComponent<EntriesAreaGroupScript>();
    //     entryImageOutline = transform.parent.parent.Find("EntryImageOutline").gameObject.GetComponent<Image>();
    //     myToggle = transform.parent.gameObject.GetComponent<Toggle>();

    //     entryImageOutline.enabled = false;
    // }

    // public void UpdateEntryButtonGraphics()
    // {
    //     entriesAreaGroupScript.DisplayActiveItem();
    //     // Debug.Log(myToggle.isOn);
    //     // if (myToggle.isOn == true)
    //     // {
    //     //     entryImageOutline.enabled = true;
    //     //     Debug.Log(gameObject.name + " is enabled");
    //     // }
    //     // else if (myToggle.isOn == false)
    //     // {
    //     //     entryImageOutline.enabled = false;
    //     //     Debug.Log(gameObject.name + " is disabled");
    //     // }
    // }
}
