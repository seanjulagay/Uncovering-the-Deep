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
        gameObject.SetActive(false);
        GameManagerScript.trashCount++;
    }
}
