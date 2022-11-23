using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    public GameObject cameraObj;

    void Start()
    {
        cameraObj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, cameraObj.transform.position.z);
    }

    void Update()
    {
        cameraObj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, cameraObj.transform.position.z);
    }
}
