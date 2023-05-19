using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AquariumButtonManagerScript : MonoBehaviour
{
    Button almanacCloseButton;
    GameObject almanacPanel;

    void Start()
    {
        almanacCloseButton = GameObject.Find("AlmanacCloseButton").GetComponent<Button>();
        almanacCloseButton.onClick.AddListener(CloseAlmanac);
        almanacPanel = GameObject.Find("AlmanacPanel");
    }

    public void CloseAlmanac()
    {
        almanacPanel.SetActive(false);
    }
}
