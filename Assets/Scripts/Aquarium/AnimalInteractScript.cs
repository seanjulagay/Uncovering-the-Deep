using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimalInteractScript : MonoBehaviour
{
    public int animalAffection = 0;
    public int maxAffection = 5;
    public bool interactedToday = false;
    public DateTime lastInteractionTime;

    void Update()
    {
        Debug.Log("last interaction time: " + lastInteractionTime);
        Debug.Log("interacted today? : " + interactedToday);
    }
}
