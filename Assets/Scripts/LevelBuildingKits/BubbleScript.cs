using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    SoundsManagerScript soundsManagerScript;
    PlayerPropertiesScript playerPropertiesScript;

    void Start()
    {
        soundsManagerScript = GameObject.Find("SoundsManager").GetComponent<SoundsManagerScript>();
        playerPropertiesScript = GameObject.Find("Player").GetComponent<PlayerPropertiesScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTrigger")
        {
            soundsManagerScript.SoundBubble();
            // playerPropertiesScript.oxygenCount += 20f;

            if (playerPropertiesScript.oxygenCount <= 79f)
            {
                playerPropertiesScript.oxygenCount += 20f;
                Debug.Log("BUBBLE COND1");
            }
            else
            {
                playerPropertiesScript.oxygenCount = 100f;
                Debug.Log("BUBBLE COND2");
            }

            gameObject.SetActive(false);
        }
    }
}
