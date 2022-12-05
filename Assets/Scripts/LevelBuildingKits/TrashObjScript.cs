using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObjScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PlayerTrigger")
        {
            Debug.Log("Triggered from " + gameObject.name);
            gameObject.SetActive(false);
            GameManagerScript.trashCount++;
        }
    }
}
