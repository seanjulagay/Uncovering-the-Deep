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
        endlessPlayerPropertiesScript.oxygenCount += 20f;
        Destroy(this.gameObject);
    }
}
