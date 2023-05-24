using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessGameManager : MonoBehaviour
{
    GameObject player;
    GameObject entryPortal;
    public int playerScore = 0;

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
