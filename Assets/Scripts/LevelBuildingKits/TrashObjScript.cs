using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObjScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;
    TrashObjRandomizerScript trashObjRandomizerScript;

    void Awake()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        trashObjRandomizerScript = GameObject.Find("TrashObjRandomizer").GetComponent<TrashObjRandomizerScript>();
        if (gameObject.tag == "TrashObjDefault")
        {
            Debug.Log("Prechange random obj");
            trashObjRandomizerScript.InstantiatRandomTrashObj(gameObject);
        }
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
