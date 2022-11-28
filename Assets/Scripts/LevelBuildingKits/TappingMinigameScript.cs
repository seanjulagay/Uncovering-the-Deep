using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappingMinigameScript : MonoBehaviour

{
    public static bool tappingMinigameOngoing = false;
    public static float freeingProgress = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log("tappingminigame:" + tappingMinigameOngoing);
    //     if (tappingMinigameOngoing == true)
    //     {
    //         startMinigame();
    //     }
    // }

    // void startMinigame()
    // {
    //     if (freeingProgress > 0)
    //     {
    //         freeingProgress -= Time.deltaTime;
    //     }
    //     else if (freeingProgress <= 0)
    //     {
    //         freeingProgress = 0;
    //     }

    //     Debug.Log("freeingProgress : " + freeingProgress);
    //     if (Input.GetKeyDown("space"))
    //     {
    //         freeingProgress += 1;
    //         Debug.Log("Pressed Space");
    //     }
    // }

    // void endMinigame()
    // {
    //     Debug.Log("Exiting minigame");
    // }
}
