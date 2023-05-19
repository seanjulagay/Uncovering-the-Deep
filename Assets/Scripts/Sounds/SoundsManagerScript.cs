using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManagerScript : MonoBehaviour
{
    public AudioSource buttonClickSound, swimmingSound, gameoverSound, bubbleSound, oxygenWarningSound, victorySound, trashSound, freeingAnimalSound;

    void Start()
    {
        buttonClickSound = GameObject.Find("ButtonSound").GetComponent<AudioSource>();

        trashSound = GameObject.Find("TrashSound").GetComponent<AudioSource>();
        freeingAnimalSound = GameObject.Find("FreeingAnimalSound").GetComponent<AudioSource>();
        
        swimmingSound = GameObject.Find("SwimmingSound").GetComponent<AudioSource>();
        bubbleSound = GameObject.Find("BubbleSound").GetComponent<AudioSource>();
        oxygenWarningSound = GameObject.Find("OxygenWarningSound").GetComponent<AudioSource>();
        
        victorySound = GameObject.Find("VictorySound").GetComponent<AudioSource>();
        gameoverSound = GameObject.Find("GameoverSound").GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void PlaySound(string sound)
    {
        if (GlobalScript.keepSoundsOn)
        {
            switch (sound)
            {
                case "buttonClick":
                    buttonClickSound.Play();
                    break;
                case "swimming":
                    swimmingSound.Play();
                    break;
                case "bubble":
                    bubbleSound.Play();
                    break;
                case "oxygenWarning":
                    oxygenWarningSound.Play();
                    break;
                case "trash":
                    trashSound.Play();
                    break;
                case "freeingAnimal":
                    freeingAnimalSound.Play();
                    break;
                case "victory":
                    victorySound.Play();
                    break;
                case "gameover":
                    gameoverSound.Play();
                    break;
                default:
                    break;
            }
        }
    }
}