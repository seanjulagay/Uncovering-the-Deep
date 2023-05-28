using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationsManager : MonoBehaviour
{
    public Animator achievement;

    void Start()
    {

    }

    public void ShowAchievement()
    {
        achievement.enabled = true;
    }
}
