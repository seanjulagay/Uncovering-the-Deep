using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBoundsScript : MonoBehaviour
{
    GameObject chasingAnimal;
    ChasingAnimalScript chasingAnimalScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ChasingAnimal")
        {
            chasingAnimal = other.gameObject;
            chasingAnimalScript = chasingAnimal.GetComponent<ChasingAnimalScript>();
        }

        if (other.gameObject.name == "PlayerTrigger")
        {
            chasingAnimalScript.isChasing = true;
        }

        if (other.gameObject == chasingAnimal)
        {
            chasingAnimalScript.inBounds = true;
        }
    }

    // void OnTriggerStay2D(Collider2D other)
    // {
    //     if (other.gameObject.name == "PlayerTrigger")
    //     {
    //         chasingAnimalScript.isChasing = true;
    //     }

    //     if (other.gameObject == chasingAnimal)
    //     {
    //         chasingAnimalScript.inBounds = true;
    //     }
    // }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTrigger")
        {
            chasingAnimalScript.isChasing = false;
        }

        if (other.gameObject == chasingAnimal)
        {
            chasingAnimalScript.inBounds = false;
        }

        if (other.gameObject.name == "PlayerTrigger" || other.gameObject == chasingAnimal)
        {
            chasingAnimalScript.ChaseBehaviorHandler();
        }
    }
}
