using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    RoomTemplates templates;

    void Start()
    {
        templates = GameObject.Find("RoomTemplates").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }
}
