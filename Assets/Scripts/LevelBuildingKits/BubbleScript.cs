using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPropertiesScript.oxygenCount += 20f;
        if (PlayerPropertiesScript.oxygenCount > 100)
        {
            PlayerPropertiesScript.oxygenCount = 99f;
        }

        gameObject.SetActive(false);
    }
}
