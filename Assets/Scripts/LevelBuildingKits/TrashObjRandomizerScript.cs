using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObjRandomizerScript : MonoBehaviour
{
    public GameObject[] trashObjPrefabs;

    public void InstantiatRandomTrashObj(GameObject gameObject)
    {
        Instantiate(trashObjPrefabs[Random.Range(0, trashObjPrefabs.Length)], gameObject.transform.position, gameObject.transform.rotation, gameObject.transform.parent);
        Destroy(gameObject);
        Debug.Log("Postchange random obj");
    }
}
