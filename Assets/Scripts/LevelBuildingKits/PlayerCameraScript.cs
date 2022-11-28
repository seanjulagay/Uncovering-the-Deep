using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    public GameObject mainCamera;

    void Start()
    {
        mainCamera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, mainCamera.transform.position.z);
    }

    void Update()
    {
        mainCamera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, mainCamera.transform.position.z);
    }
}
