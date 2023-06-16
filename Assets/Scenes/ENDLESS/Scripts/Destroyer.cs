using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EndlessClosedWall")
        {
            Debug.Log("DELETING CLOSED WALL");
            Destroy(other.gameObject);
        }
    }
}
