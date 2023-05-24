using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessGameManager : MonoBehaviour
{
    GameObject player;
    GameObject entryPortal;

    void Start()
    {
        player = GameObject.Find("Player");
        entryPortal = GameObject.Find("EntryPortal");

        player.transform.position = entryPortal.transform.position;
    }

    public void GameOver()
    {
        Debug.Log("Game over!");
    }

}
