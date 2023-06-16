using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    AudioSource music;

    void Start()
    {
        music = gameObject.GetComponent<AudioSource>();

        if (SceneDataHandler.activeUser.musicOn == true)
        {
            music.Play();
        }
        else
        {
            music.Stop();
        }
    }
}
