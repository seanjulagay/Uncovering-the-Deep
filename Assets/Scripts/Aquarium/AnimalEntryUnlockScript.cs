using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalEntryUnlockScript : MonoBehaviour
{
    /*
    ANIMAL IDs:
    - 00: Sea Turtle
    - 01: Clownfish
    - 02: Whaleshark
    - 03: Manta Ray
    - 04: Jellyfish
    - 05: Ghost Shark
    - 06: Gulper Eel
    - 07: Angler Fish
    - 08: Vampire Squid
    - 09: Horeshoe Crab
    - 10: Dumbo Octopus
    - 11: Sperm Whale
    */

    public List<GameObject> animalEntries = new List<GameObject>();

    public List<string> origName = new List<string>();
    public List<Image> origImage = new List<Image>();
    public List<string> origDesc = new List<string>();
    public List<string> origDepthZone = new List<string>();
    public List<string> origAnimalFunFact = new List<string>();

    void Awake()
    {
        Debug.Log("Entries count: " + animalEntries.Count);
        StoreOrigData();
        BlackoutEntries();
        FillEntries();
    }

    void StoreOrigData()
    {
        for (int i = 0; i < animalEntries.Count; i++)
        {
            Debug.Log("STORING ORIG DATA" + i);
            origName.Add(animalEntries[i].transform.Find("EntryText").GetComponent<TMP_Text>().text);
            // origImage[i] = animalEntries[i].transform.Find("EntryButton").GetChild(0).GetComponent<Image>();
            origDesc.Add(animalEntries[i].GetComponent<EntryBoxScript>().entryDescription);
            origDepthZone.Add(animalEntries[i].GetComponent<EntryBoxScript>().animalDepthZone);
            origAnimalFunFact.Add(animalEntries[i].GetComponent<EntryBoxScript>().animalFunFact);
        }
    }

    void BlackoutEntries()
    {
        for (int i = 0; i < animalEntries.Count; i++)
        {
            animalEntries[i].transform.Find("EntryText").GetComponent<TMP_Text>().text = "???"; // NAME
            animalEntries[i].transform.Find("EntryButton").GetChild(0).GetComponent<Image>().color = Color.black;
            animalEntries[i].transform.GetComponent<EntryBoxScript>().entryDescription = "???";
            animalEntries[i].transform.GetComponent<EntryBoxScript>().animalDepthZone = "???";
            animalEntries[i].transform.GetComponent<EntryBoxScript>().animalFunFact = "???";
            animalEntries[i].transform.GetComponent<EntryBoxScript>().isUnlocked = false;
        }
    }

    void FillEntries()
    {
        for (int i = 0; i < animalEntries.Count; i++)
        {
            if (SceneDataHandler.activeUser.hasUnlockedAlmanacAnimal[i] == true)
            {
                animalEntries[i].transform.Find("EntryText").GetComponent<TMP_Text>().text = origName[i]; // NAME
                animalEntries[i].transform.Find("EntryButton").GetChild(0).GetComponent<Image>().color = Color.white;
                animalEntries[i].transform.GetComponent<EntryBoxScript>().entryDescription = origDesc[i];
                animalEntries[i].transform.GetComponent<EntryBoxScript>().animalDepthZone = origDepthZone[i];
                animalEntries[i].transform.GetComponent<EntryBoxScript>().animalFunFact = origAnimalFunFact[i];
                animalEntries[i].transform.GetComponent<EntryBoxScript>().isUnlocked = true;
            }
        }
    }
}
