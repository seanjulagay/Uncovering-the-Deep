using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimalInteractScript : MonoBehaviour
{
    UIProgressBarScript uiProgressBarScript;

    public int animalAffection = 0;
    public int maxAffection = 3;
    public DateTime lastInteractionTime;

    void Awake()
    {
        uiProgressBarScript = GameObject.Find("AffectionBar").GetComponent<UIProgressBarScript>();
    }

    public void UpdateAffectionBar()
    {
        uiProgressBarScript.maximum = 3;
        uiProgressBarScript.current = animalAffection;
    }
}
