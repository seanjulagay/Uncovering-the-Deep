using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappingMinigameScript : MonoBehaviour

{
    public static bool tappingMinigameOngoing = false;
    float freeingProgress = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("tappingminigame:" + tappingMinigameOngoing);
        if (tappingMinigameOngoing == true)
        {
            startMinigame();
        }
    }

    void startMinigame()
    {
        Debug.Log("Hello world!");
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Pressed Space");
        }
    }

    void endMinigame()
    {
        Debug.Log("Exiting minigame");
    }
}
