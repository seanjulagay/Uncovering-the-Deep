using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquariumBoundsScript : MonoBehaviour
{
    GameObject aquariumAnimal;
    AquariumAnimalMovementScript aquariumAnimalMovementScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AquariumAnimal")
        {
            aquariumAnimal = other.gameObject;
            aquariumAnimalMovementScript = aquariumAnimal.GetComponent<AquariumAnimalMovementScript>();
        }
    }
}
