using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    PlayerPropertiesScript playerPropertiesScript;

    void Start()
    {
        playerPropertiesScript = GameObject.Find("Player").GetComponent<PlayerPropertiesScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTrigger")
        {
            playerPropertiesScript.oxygenCount += 20f;
            if (other.gameObject.tag == "Player")
            {
                if (playerPropertiesScript.oxygenCount <= 99f)
                {
                    playerPropertiesScript.oxygenCount += 20f;
                    if (playerPropertiesScript.oxygenCount >= 100f)
                    {
                        playerPropertiesScript.oxygenCount = 99f;
                    }
                }
            }
            gameObject.SetActive(false);
        }
    }
}
