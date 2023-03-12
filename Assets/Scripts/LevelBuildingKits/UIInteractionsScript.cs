using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteractionsScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    public void ToggleGamePause()
    {
        gameManagerScript.ToggleGamePause();
    }
}
