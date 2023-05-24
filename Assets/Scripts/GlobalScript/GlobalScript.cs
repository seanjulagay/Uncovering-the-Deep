using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    public static bool keepMusicOn = true;
    public static bool keepSoundsOn = true;
    public static int  currentGameMode = 0; // 0 = story, 1 = endless

    public static void SaveSettings(bool musicOn, bool soundsOn) {
        keepMusicOn = musicOn;
        keepSoundsOn = soundsOn;
    }
}
