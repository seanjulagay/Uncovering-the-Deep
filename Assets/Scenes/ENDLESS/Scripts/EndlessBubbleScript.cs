using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBubbleScript : MonoBehaviour
{
    EndlessPlayerPropertiesScript endlessPlayerPropertiesScript;

    void Awake()
    {
        endlessPlayerPropertiesScript = GameObject.Find("Player").GetComponent<EndlessPlayerPropertiesScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (endlessPlayerPropertiesScript.oxygenCount <= 99f)
            {
                endlessPlayerPropertiesScript.oxygenCount += 20f;
                if (endlessPlayerPropertiesScript.oxygenCount >= 100f)
                {
                    endlessPlayerPropertiesScript.oxygenCount = 99f;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
