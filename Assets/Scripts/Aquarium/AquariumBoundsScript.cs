using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquariumBoundsScript : MonoBehaviour
{
    GameObject aquariumAnimal;
    AquariumAnimalScript aquariumAnimalScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AquariumAnimal")
        {
            aquariumAnimal = other.gameObject;
            aquariumAnimalScript = aquariumAnimal.GetComponent<AquariumAnimalScript>();
        }
    }
}
