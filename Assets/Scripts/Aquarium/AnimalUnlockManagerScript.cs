using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AnimalUnlockManagerScript : MonoBehaviour
{
    public List<GameObject> animals = new List<GameObject>();

    void Start()
    {
        Debug.Log("String: " + SceneDataHandler.activeUser.lastInteractionTime[0]);
        HideAllAnimals();
        LoadAnimals();
        LoadInteractionStatus();
    }

    public void LoadInteractionStatus()
    {
        Debug.Log("Loading interaction status");
        for (int i = 0; i < animals.Count; i++)
        {
            animals[i].transform.GetChild(0).GetComponent<AnimalInteractScript>().lastInteractionTime = DateTime.Parse(SceneDataHandler.activeUser.lastInteractionTime[i]);
            // Debug.Log(animals[i].name + " last interaction time: " + animals[i].transform.GetChild(0).GetComponent<AnimalInteractScript>().lastInteractionTime);
            animals[i].transform.GetChild(0).GetComponent<AnimalInteractScript>().animalAffection = SceneDataHandler.activeUser.interactionLevel[i];
        }
    }

    public void SaveInteractionStatus()
    {
        Debug.Log("Saving interaction status");
        for (int i = 0; i < animals.Count; i++)
        {
            SceneDataHandler.activeUser.lastInteractionTime[i] = animals[i].transform.GetChild(0).GetComponent<AnimalInteractScript>().lastInteractionTime.ToString();
            // Debug.Log("Saved: " + SceneDataHandler.activeUser.lastInteractionTime[i]);
            SceneDataHandler.activeUser.interactionLevel[i] = animals[i].transform.GetChild(0).GetComponent<AnimalInteractScript>().animalAffection;
        }
        SceneDataHandler.TransferTempData();
    }

    void HideAllAnimals()
    {
        for (int i = 0; i < animals.Count; i++)
        {
            animals[i].SetActive(false);
            Debug.Log(animals[i].name + " has been deactivated");
        }
    }

    void LoadAnimals()
    {
        Debug.Log("Current zone: " + SceneDataHandler.activeUser.currentZone);
        Debug.Log("Current level: " + SceneDataHandler.activeUser.currentLevel);
        // for (int i = 0; i < SceneDataHandler.activeUser.currentLevel; i++)
        // {
        //     if (SceneDataHandler.activeUser.currentZone >= 0)
        //     {
        //         animals[i].SetActive(true);
        //         Debug.Log(animals[i].name + " loaded");
        //         if (SceneDataHandler.activeUser.currentZone >= 1)
        //         {
        //             animals[i + 2].SetActive(true);
        //             Debug.Log(animals[i + 2].name + " loaded");
        //             if (SceneDataHandler.activeUser.currentLevel >= 2)
        //             {
        //                 animals[i + 4].SetActive(true);
        //                 Debug.Log(animals[i + 4].name + " loaded");
        //             }
        //         }
        //     }
        // }

        if (SceneDataHandler.activeUser.currentZone == 0)
        {
            SetAnimalActiveLevel();
        }
        else if (SceneDataHandler.activeUser.currentZone == 1)
        {
            SetAnimalActiveLevel(2);
        }
        else if (SceneDataHandler.activeUser.currentZone == 2)
        {
            SetAnimalActiveLevel(4);
        }
    }

    void SetAnimalActiveLevel(int add = 0)
    {
        for (int i = 0; i < SceneDataHandler.activeUser.currentLevel + add; i++)
        {
            animals[i].SetActive(true);
        }
    }
}
