using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EntriesAreaGroupScript : MonoBehaviour
{
    ToggleGroup group;

    void Start()
    {
        group = gameObject.GetComponent<ToggleGroup>();
    }

    public void DisplayActiveItem()
    {
        Toggle toggle = group.ActiveToggles().FirstOrDefault();
        Debug.Log("activeToggle: " + toggle.name);
    }
}
