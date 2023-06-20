using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 - need bottom door
    // 2 - need top door
    // 3 - need left door
    // 4 - need right door

    RoomTemplates roomTemplates;
    int rand;
    public bool spawned = false;

    void Awake()
    {
        roomTemplates = GameObject.Find("RoomTemplates").GetComponent<RoomTemplates>();
    }

    void Start()
    {
        BeginSpawn();
    }

    public void BeginSpawn()
    {
        float rand = UnityEngine.Random.Range(0.05f, 0.1000001f);
        Invoke("Spawn", rand);
        Debug.Log("Loaded cell in " + rand + " secs");
        // Invoke("Spawn", 0.01f);
    }

    public void Spawn()
    {
        Debug.Log("Spawning");
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                // need to spawn a room with bottom door
                Debug.Log("bottomRooms: " + roomTemplates.leftRooms.Length);
                rand = UnityEngine.Random.Range(0, roomTemplates.bottomRooms.Length - 1);
                Instantiate(roomTemplates.bottomRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                // need to spawn a room with top door
                Debug.Log("topRooms: " + roomTemplates.leftRooms.Length);
                rand = UnityEngine.Random.Range(0, roomTemplates.topRooms.Length - 1);
                Instantiate(roomTemplates.topRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                // need to spawn a room with left door
                Debug.Log("leftRooms: " + roomTemplates.leftRooms.Length);
                rand = UnityEngine.Random.Range(0, roomTemplates.leftRooms.Length - 1);
                Instantiate(roomTemplates.leftRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                // need to spawn a room with rightdoor
                Debug.Log("rightRooms: " + roomTemplates.leftRooms.Length);
                rand = UnityEngine.Random.Range(0, roomTemplates.rightRooms.Length - 1);
                Instantiate(roomTemplates.rightRooms[rand], transform.position, Quaternion.identity);
            }

            if (openingDirection != 0)
            {
                Instantiate(roomTemplates.RandomizeContentCell(), transform.position, Quaternion.identity);
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SpawnPoint")
        {
            Debug.Log("TOUCHED SPAWNPOINT");
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Debug.Log("FULFILLED CONDITION");
                Instantiate(roomTemplates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}