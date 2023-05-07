using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryAnimalTriggerScript : MonoBehaviour
{
    UIManagerScript uiManagerScript;
    GameManagerScript gameManagerScript;

    public bool metAnimalYet = false;

    void Start()
    {
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && metAnimalYet == false)
        {
            metAnimalYet = true;
            gameManagerScript.animalsMet++;
        }
    }


}
