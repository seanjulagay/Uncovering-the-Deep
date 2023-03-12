using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPointScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;
    CheckpointManagerScript checkpointManagerScript;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        checkpointManagerScript = GameObject.Find("CheckpointManager").GetComponent<CheckpointManagerScript>();
    }

    void TouchedFinishPoint()
    {
        checkpointManagerScript.TurnAllTrashbagsStackable();
        GameManagerScript.inStackingState = true;
        // Debug.Log("AAAA");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TouchedFinishPoint();
            gameManagerScript.LevelCompleted(3);
        }
    }
}
