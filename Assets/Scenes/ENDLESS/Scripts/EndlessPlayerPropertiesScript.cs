using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessPlayerPropertiesScript : MonoBehaviour
{
    EndlessGameManager endlessGameManager;
    float oxygenCount = 99f;

    void Start()
    {
        endlessGameManager = GameObject.Find("EndlessGameManager").GetComponent<EndlessGameManager>();
    }

    void PlayerOxygenHandler()
    {
        if (oxygenCount > 0f)
        {
            oxygenCount -= Time.deltaTime;
        }
        else
        {
            endlessGameManager.GameOver();
        }
    }
}
