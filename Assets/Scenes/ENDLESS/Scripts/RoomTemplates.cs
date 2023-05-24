using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public GameObject entryPortalPf;
    public GameObject exitPortalPf;

    public float waitTime = 1.5f;
    public bool spawnedExit;

    void Update()
    {
        if (waitTime <= 0 && spawnedExit == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Instantiate(exitPortalPf, rooms[i].transform.position, Quaternion.identity);
                    spawnedExit = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
