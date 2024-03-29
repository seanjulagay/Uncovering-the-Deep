using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBubbleObjScript : MonoBehaviour
{
    SoundsManagerScript soundsManagerScript;
    MovingBubbleScript movingBubbleScript;
    PlayerPropertiesScript playerPropertiesScript;

    void Start()
    {
        soundsManagerScript = GameObject.Find("SoundsManager").GetComponent<SoundsManagerScript>();
        movingBubbleScript = gameObject.transform.parent.gameObject.GetComponent<MovingBubbleScript>();
        playerPropertiesScript = GameObject.Find("Player").GetComponent<PlayerPropertiesScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTrigger")
        {
            playerPropertiesScript.oxygenCount += 20f;
            if (playerPropertiesScript.oxygenCount > 100)
            {
                playerPropertiesScript.oxygenCount = 99f;
            }
            soundsManagerScript.SoundBubble();
            movingBubbleScript.BubbleDestroyed();
        }
    }
}
