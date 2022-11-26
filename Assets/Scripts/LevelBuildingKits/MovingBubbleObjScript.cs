using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBubbleObjScript : MonoBehaviour
{
    MovingBubbleScript movingBubbleScript;

    void Start()
    {
        movingBubbleScript = gameObject.transform.parent.gameObject.GetComponent<MovingBubbleScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPropertiesScript.oxygenCount += 20f;
            if (PlayerPropertiesScript.oxygenCount > 100)
            {
                PlayerPropertiesScript.oxygenCount = 99f;
            }

            movingBubbleScript.BubbleDestroyed();
        }
    }
}
