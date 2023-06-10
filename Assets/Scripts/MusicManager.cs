using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    AudioSource music;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            music = GameObject.Find("MusicManager").GetComponent<AudioSource>();
        }
        else
        {
            music = GameObject.Find("Music").GetComponent<AudioSource>();
            Debug.Log("Music: " + music.clip.name);
        }

        ToggleMusic();
    }

    public void ToggleMusic()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (ProfileManagerScript.activeUser.musicOn == true)
            {
                if (music.isPlaying == false)
                {
                    music.Play();
                }
            }
            else
            {
                music.Stop();
            }
        }
        else
        {
            if (SceneDataHandler.activeUser.musicOn == true)
            {
                if (music.isPlaying == false)
                {
                    music.Play();
                }
            }
            else
            {
                music.Stop();
            }
        }

        // if (SceneDataHandler.activeUser.musicOn == true)
        // {
        //     Debug.Log("Enabling music");
        //     if (music.isPlaying == false)
        //     {
        //         music.Play();
        //     }
        // }
        // else
        // {
        //     Debug.Log("Disabling music");
        //     music.Stop();
        // }
    }
}
