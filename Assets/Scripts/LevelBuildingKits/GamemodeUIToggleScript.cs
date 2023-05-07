using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemodeUIToggleScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;

    GameObject explorationPanel, restorationPanel;

    void Awake()
    {
        explorationPanel = GameObject.Find("ExplorationPanel");
        restorationPanel = GameObject.Find("RestorationPanel");
    }

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        if (gameManagerScript.gameMode == 0)
        {
            explorationPanel.SetActive(true);
            restorationPanel.SetActive(false);
        }
        else
        {
            explorationPanel.SetActive(false);
            restorationPanel.SetActive(true);
        }
    }


}
