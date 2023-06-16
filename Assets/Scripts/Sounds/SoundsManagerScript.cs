using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundsManagerScript : MonoBehaviour
{
    public AudioSource buttonClickSound, swimmingSound, gameoverSound, bubbleSound, oxygenWarningSound, victorySound, trashSound, freeingAnimalSound, engineSound, whirlpoolSound;

    void Start()
    {
        // buttonClickSound = GameObject.Find("ButtonSound").GetComponent<AudioSource>();

        // trashSound = GameObject.Find("TrashSound").GetComponent<AudioSource>();
        // freeingAnimalSound = GameObject.Find("FreeingAnimalSound").GetComponent<AudioSource>();

        // swimmingSound = GameObject.Find("SwimmingSound").GetComponent<AudioSource>();
        // bubbleSound = GameObject.Find("BubbleSound").GetComponent<AudioSource>();
        // oxygenWarningSound = GameObject.Find("OxygenWarningSound").GetComponent<AudioSource>();

        // victorySound = GameObject.Find("VictorySound").GetComponent<AudioSource>();
        // gameoverSound = GameObject.Find("GameoverSound").GetComponent<AudioSource>();
    }

    public void SoundWhirlpool()
    {
        try
        {
            Debug.Log("SoundWhirlpool");
            if (SceneDataHandler.activeUser.soundOn == true)
            {
                whirlpoolSound.Play();
            }
        }
        catch (Exception e)
        {
            Debug.Log("No whirlpool sound detected");
        }
    }

    public void SoundButonClick()
    {
        Debug.Log("SoundButtonClick");
        if (SceneDataHandler.activeUser.soundOn == true)
        {
            buttonClickSound.Play();
        }
    }

    public void SoundEngine()
    {
        Debug.Log("EngineSound");
        if (SceneDataHandler.activeUser.soundOn == true && Time.timeScale == 1)
        {
            if (engineSound.isPlaying == false)
            {
                Debug.Log("PLAYING ENGINE SOUND");
                engineSound.Play();
            }
        }
    }

    public void SoundSwimming()
    {
        Debug.Log("SoundSwimming");
        if (SceneDataHandler.activeUser.soundOn == true)
        {
            if (swimmingSound.isPlaying == false)
            {
                swimmingSound.Play();
            }
        }
    }

    public void SoundBubble()
    {
        Debug.Log("SoundBubble");
        if (SceneDataHandler.activeUser.soundOn == true)
        {
            if (bubbleSound.isPlaying == false)
            {
                bubbleSound.Play();
            }
        }
    }

    public void SoundOxygenWarning()
    {
        Debug.Log("SoundOxygenWarning");
        if (SceneDataHandler.activeUser.soundOn == true)
        {
            if (oxygenWarningSound.isPlaying == false)
            {
                oxygenWarningSound.Play();
            }
        }
    }

    public void SoundTrash()
    {
        Debug.Log("SoundTrash");
        if (SceneDataHandler.activeUser.soundOn == true)
        {
            trashSound.Play();
        }
    }

    public void SoundFreeingAnimal()
    {
        Debug.Log("SoundFreeingAnimal");
        if (SceneDataHandler.activeUser.soundOn == true)
        {
            freeingAnimalSound.Play();
        }
    }

    public void SoundVictory()
    {
        Debug.Log("SoundVictory");
        if (SceneDataHandler.activeUser.soundOn == true)
        {
            victorySound.Play();
        }
    }

    public void SoundGameOver()
    {
        Debug.Log("SoundGameOver");
        if (SceneDataHandler.activeUser.soundOn == true)
        {
            gameoverSound.Play();
        }
    }

    public void PlaySound(string sound)
    {
        if (SceneDataHandler.activeUser.soundOn == true)
        {
            Debug.Log("PLAYING SOUNDS");
            switch (sound)
            {
                case "buttonClick":
                    buttonClickSound.Play();
                    break;
                case "swimming":
                    swimmingSound.Play();
                    Debug.Log("SWIMMING" + swimmingSound.isPlaying);
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
                case "gameOver":
                    gameoverSound.Play();
                    break;
                default:
                    break;
            }
        }
    }
}
