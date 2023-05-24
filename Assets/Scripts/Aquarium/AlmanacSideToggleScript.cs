using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AlmanacSideToggleScript : MonoBehaviour
{
    ToggleGroup toggleGroup;

    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();

        
    }

    void GetActiveToggle()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
    }
}
