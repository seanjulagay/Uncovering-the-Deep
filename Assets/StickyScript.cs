using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyScript : MonoBehaviour
{
    public GameObject characterHead;
    public Vector3 desiredPosition = new Vector3(0f, 0.6f, 0f);
    public Vector3 desiredRotation = new Vector3(0f, 0f, 0f);


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Attach the object to the character's head
            transform.SetParent(characterHead.transform, true);

            // Adjust position and rotation
            transform.localPosition = desiredPosition;
            transform.localRotation = Quaternion.Euler(desiredRotation);
        }
    }
}
